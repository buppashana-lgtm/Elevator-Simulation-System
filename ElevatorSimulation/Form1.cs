using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace ElevatorSimulation
{
    public partial class Form1 : Form
    {
        string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=ElevatorSystem;Integrated Security=True;TrustServerCertificate=True;";
        int floorA = 0;
        int floorB = 1;

        Elevator liftAState = new Elevator();
        Elevator liftBState = new Elevator();

        ElevatorSubject elevatorSubjectA = new ElevatorSubject();
        ElevatorSubject elevatorSubjectB = new ElevatorSubject();


        ElevatorDisplay displayA;
        ElevatorDisplay displayB;

        int destinationA = 0;
        int destinationB = 1;

        bool movingA = false;
        bool movingB = false;

        int liftAStartY;
        int liftBStartY;

        int liftASpeed = 2;
        int liftBSpeed = 2;

        int cabinAStartY;
        int cabinBStartY;

        int cabinAEndY;
        int cabinBEndY;

        int doorSpeedA = 0;
        int doorSpeedB = 0;

        bool doorOpeningA = false;
        bool doorOpeningB = false;

        int doorLeftAStartX;
        int doorRightAStartX;

        int doorLeftBStartX;
        int doorRightBStartX;

        bool doorClosingA = false;
        bool doorClosingB = false;

        int doorWaitA = 0;
        int doorWaitB = 0;

        DateTime requestTimeA;
        DateTime requestTimeB;

        DateTime startTimeA;
        DateTime startTimeB;

        int travelSecondsA;
        int travelSecondsB;

        int logIdA = 0;
        int logIdB = 0;

        bool liftAStatusLogged = false;
        bool liftBStatusLogged = false;

        bool liftAClosingLogged = false;
        bool liftBClosingLogged = false;

        bool emergencyActive = false;
        public Form1()
        {
            InitializeComponent();
            TestDatabaseConnection();

            displayA = new ElevatorDisplay(lblDoorA);
            displayB = new ElevatorDisplay(lblDoorB);

            elevatorSubjectA.AddObserver(displayA);
            elevatorSubjectB.AddObserver(displayB);

            liftAState.SetState(new IdleState());
            liftBState.SetState(new IdleState());

            lblDoorA.Text = "Door: Closed";
            lblDoorB.Text = "Door: Closed";

            lblFloorA.Text = "Floor: " + floorA;
            lblFloorB.Text = "Floor: " + floorB;

            lblStatus0.Text = "Floor 0: Lift A";
            lblStatus1.Text = "Floor 1: Lift B";

            liftAStartY = pnlLiftA.Top;
            liftBStartY = pnlLiftB.Top;

            cabinAStartY = pnlDoorLeftA.Top;
            cabinBStartY = pnlDoorLeftB.Top;

            pnlDoorRightA.Top = pnlDoorLeftA.Top;
            pnlDoorRightB.Top = pnlDoorLeftB.Top;

            doorLeftAStartX = pnlDoorLeftA.Left;
            doorRightAStartX = pnlDoorRightA.Left;

            doorLeftBStartX = pnlDoorLeftB.Left;
            doorRightBStartX = pnlDoorRightB.Left;

        }
        private void TestDatabaseConnection()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    MessageBox.Show("Database Connected Successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message);
                }
            }
        }
        private int SaveLog(string elevator, int fromFloor, int toFloor, string action)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO dbo.ElevatorLogs
        (ElevatorName, FromFloor, ToFloor, Action, RequestTime)
        VALUES (@name, @from, @to, @action, GETDATE());
        SELECT SCOPE_IDENTITY();";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@name", elevator);
                cmd.Parameters.AddWithValue("@from", fromFloor);
                cmd.Parameters.AddWithValue("@to", toFloor);
                cmd.Parameters.AddWithValue("@action", action);

                con.Open();

                int id = Convert.ToInt32(cmd.ExecuteScalar());

                LoadLogs();

                return id;
            }
        }

        private void UpdateArrival(int logId, DateTime startTime)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"UPDATE dbo.ElevatorLogs
                         SET StartTime = @start,
                             ArrivalTime = GETDATE(),
                             TravelSeconds = DATEDIFF(SECOND, @start, GETDATE())
                         WHERE LogID = @id";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@start", startTime);
                cmd.Parameters.AddWithValue("@id", logId);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadLogs();
        }

        private void UpdateDoorLog(int logId, string status)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"UPDATE dbo.ElevatorLogs
                         SET DoorStatus = @status,
                             DoorOpenTime = CASE
                                 WHEN @status = 'Open' THEN GETDATE()
                                 ELSE DoorOpenTime END,
                             DoorCloseTime = CASE
                                 WHEN @status = 'Closed' THEN GETDATE()
                                 ELSE DoorCloseTime END,
                             DurationSeconds = CASE
                                 WHEN @status = 'Closed'
                                 THEN DATEDIFF(SECOND, DoorOpenTime, GETDATE())
                                 ELSE DurationSeconds END
                         WHERE LogID = @id";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@id", logId);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadLogs();
        }

        private void LoadLogs()
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // =========================
            // LIFT A MOVEMENT
            // =========================

            if (movingA == true &&
                doorOpeningA == false &&
                doorClosingA == false &&
                lblDoorA.Text == "Door: Closed")
            {
                liftAState.SetState(new MovingState());
                liftAState.PerformAction();

                if (liftAStatusLogged == false)
                {
                    if (destinationA > floorA)
                        UpdateDoorLog(logIdA, "Moving Up");
                    else if (destinationA < floorA)
                        UpdateDoorLog(logIdA, "Moving Down");

                    liftAStatusLogged = true;
                }

                if (destinationA > floorA)
                    lblFloorA.Text = "Floor: " + floorA + " ↑";
                else if (destinationA < floorA)
                    lblFloorA.Text = "Floor: " + floorA + " ↓";

                // Calculate destination inside the fixed gray shaft
                int targetA;

                if (destinationA == 1)
                    targetA = 0;
                else
                    targetA = pnlLiftA.ClientSize.Height -
                              pnlDoorLeftA.Height;

                // Check whether Lift A has reached its destination
                if (Math.Abs(pnlDoorLeftA.Top - targetA) <= 2)
                {
                    // Set both blue panels to the exact position
                    pnlDoorLeftA.Top = targetA;
                    pnlDoorRightA.Top = targetA;

                    UpdateArrival(logIdA, startTimeA);

                    movingA = false;
                    floorA = destinationA;

                    lblFloorA.Text = "Floor: " + floorA;

                    UpdateDoorLog(logIdA, "Opening");

                    liftAState.SetState(new DoorOpenState());
                    liftAState.PerformAction();

                    doorOpeningA = true;
                    doorClosingA = false;

                    liftAClosingLogged = false;

                    doorWaitA = 0;

                    timer2.Start();
                }
                else if (pnlDoorLeftA.Top < targetA)
                {
                    // Move blue panels downward
                    pnlDoorLeftA.Top += 2;
                    pnlDoorRightA.Top += 2;
                }
                else
                {
                    // Move blue panels upward
                    pnlDoorLeftA.Top -= 2;
                    pnlDoorRightA.Top -= 2;
                }
            }


            // =========================
            // LIFT B MOVEMENT
            // =========================

            if (movingB == true &&
                doorOpeningB == false &&
                doorClosingB == false &&
                lblDoorB.Text == "Door: Closed")
            {
                liftBState.SetState(new MovingState());
                liftBState.PerformAction();

                if (liftBStatusLogged == false)
                {
                    if (destinationB > floorB)
                        UpdateDoorLog(logIdB, "Moving Up");
                    else if (destinationB < floorB)
                        UpdateDoorLog(logIdB, "Moving Down");

                    liftBStatusLogged = true;
                }

                if (destinationB > floorB)
                    lblFloorB.Text = "Floor: " + floorB + " ↑";
                else if (destinationB < floorB)
                    lblFloorB.Text = "Floor: " + floorB + " ↓";

                // Calculate destination inside the fixed gray shaft
                int targetB;

                if (destinationB == 1)
                    targetB = 0;
                else
                    targetB = pnlLiftB.ClientSize.Height -
                              pnlDoorLeftB.Height;

                // Check whether Lift B has reached its destination
                if (Math.Abs(pnlDoorLeftB.Top - targetB) <= 2)
                {
                    // Set both blue panels to the exact position
                    pnlDoorLeftB.Top = targetB;
                    pnlDoorRightB.Top = targetB;

                    UpdateArrival(logIdB, startTimeB);

                    movingB = false;
                    floorB = destinationB;

                    lblFloorB.Text = "Floor: " + floorB;

                    UpdateDoorLog(logIdB, "Opening");

                    liftBState.SetState(new DoorOpenState());
                    liftBState.PerformAction();

                    doorOpeningB = true;
                    doorClosingB = false;

                    liftBClosingLogged = false;

                    doorWaitB = 0;

                    timer2.Start();
                }
                else if (pnlDoorLeftB.Top < targetB)
                {
                    // Move blue panels downward
                    pnlDoorLeftB.Top += 2;
                    pnlDoorRightB.Top += 2;
                }
                else
                {
                    // Move blue panels upward
                    pnlDoorLeftB.Top -= 2;
                    pnlDoorRightB.Top -= 2;
                }
            }


            // =========================
            // FLOOR STATUS UPDATE
            // =========================

            string floor0Lifts = "";
            string floor1Lifts = "";

            if (floorA == 0)
                floor0Lifts += "Lift A ";

            if (floorB == 0)
                floor0Lifts += "Lift B";

            if (floorA == 1)
                floor1Lifts += "Lift A ";

            if (floorB == 1)
                floor1Lifts += "Lift B";

            lblStatus0.Text = "Floor 0: " +
                (floor0Lifts == "" ? "No Lift" : floor0Lifts);

            lblStatus1.Text = "Floor 1: " +
                (floor1Lifts == "" ? "No Lift" : floor1Lifts);
        }

        private void btnRequest0_Click(object sender, EventArgs e)
        {

            if (emergencyActive == true)
            {
                MessageBox.Show("Emergency Active! Reset first.");
                return;
            }
            if (movingA == false &&
            doorOpeningA == false &&
            doorClosingA == false &&
            lblDoorA.Text == "Door: Closed")
            {
                destinationA = 0;
                movingA = true;
                liftAStatusLogged = false;
                requestTimeA = DateTime.Now;
                startTimeA = DateTime.Now;

                logIdA = SaveLog("Lift A", floorA, 0, "Request");

                timer1.Start();
            }
            else if (movingB == false &&
                     doorOpeningB == false &&
                     doorClosingB == false &&

                     lblDoorB.Text == "Door: Closed")
            {
                destinationB = 0;
                movingB = true;
                liftBStatusLogged = false;
                requestTimeB = DateTime.Now;
                startTimeB = DateTime.Now;

                logIdB = SaveLog("Lift B", floorB, 0, "Request");

                timer1.Start();
            }
        }

        private void btnRequests1_Click(object sender, EventArgs e)
        {
            if (emergencyActive == true)
            {
                MessageBox.Show("Emergency Active! Reset first.");
                return;
            }
            if (movingA == false &&
            doorOpeningA == false &&
            doorClosingA == false &&
            lblDoorA.Text == "Door: Closed")
            {
                destinationA = 1;
                movingA = true;
                liftAStatusLogged = false;
                requestTimeA = DateTime.Now;
                startTimeA = DateTime.Now;

                logIdA = SaveLog("Lift A", floorA, 0, "Request");

                timer1.Start();
            }
            else if (movingB == false &&
                     doorOpeningB == false &&
                     doorClosingB == false &&
                     lblDoorB.Text == "Door: Closed")
            {
                destinationB = 1;
                movingB = true;
                liftBStatusLogged = false;
                requestTimeB = DateTime.Now;
                startTimeB = DateTime.Now;

                logIdB = SaveLog("Lift B", floorB, 0, "Request");

                timer1.Start();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

            timer1.Start();
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

            if (emergencyActive == true)
            {
                emergencyActive = false;

                // Stop lift movement
                movingA = false;
                movingB = false;

                
                // Restore Lift A doors
                pnlDoorLeftA.Left = doorLeftAStartX;
                pnlDoorRightA.Left = doorRightAStartX;

                // Restore Lift B doors
                pnlDoorLeftB.Left = doorLeftBStartX;
                pnlDoorRightB.Left = doorRightBStartX;

                doorOpeningA = false;
                doorOpeningB = false;
                doorClosingA = false;
                doorClosingB = false;

                lblDoorA.Text = "Door: Closed";
                lblDoorB.Text = "Door: Closed";

                btnEmergency.BackColor = Color.Red;

                MessageBox.Show(
                    "Emergency Reset Successful!",
                    "System Reset",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }

        }

        private void btnA0_Click(object sender, EventArgs e)
        {
            if (movingA == false)
            {
                destinationA = 0;
                movingA = true;

                liftAStatusLogged = false;

                requestTimeA = DateTime.Now;
                startTimeA = DateTime.Now;

                logIdA = SaveLog("Lift A", floorA, 0, "Internal Request");

                timer1.Start();
            }
        }

        private void btnB1_Click(object sender, EventArgs e)
        {
            if (movingB == false)
            {
                destinationB = 1;
                movingB = true;

                liftBStatusLogged = false;

                requestTimeB = DateTime.Now;
                startTimeB = DateTime.Now;

                logIdB = SaveLog("Lift B", floorB, 1, "Internal Request");

                timer1.Start();
            }
        }

        private void btnA1_Click(object sender, EventArgs e)
        {
            if (movingA == false)
            {
                destinationA = 1;
                movingA = true;

                liftAStatusLogged = false;

                requestTimeA = DateTime.Now;
                startTimeA = DateTime.Now;

                logIdA = SaveLog("Lift A", floorA, 1, "Internal Request");

                timer1.Start();
            }
        }

        private void btnB0_Click(object sender, EventArgs e)
        {
            if (movingB == false)
            {
                destinationB = 0;
                movingB = true;

                liftBStatusLogged = false;

                requestTimeB = DateTime.Now;
                startTimeB = DateTime.Now;

                logIdB = SaveLog("Lift B", floorB, 0, "Internal Request");

                timer1.Start();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            // =========================
            // LIFT A - OPENING
            // =========================

            if (doorOpeningA)
            {
                int openLeftA = doorLeftAStartX - pnlDoorLeftA.Width;
                int openRightA = doorRightAStartX + pnlDoorRightA.Width;

                if (pnlDoorLeftA.Left > openLeftA)
                    pnlDoorLeftA.Left = Math.Max(
                        openLeftA, pnlDoorLeftA.Left - 2);

                if (pnlDoorRightA.Left < openRightA)
                    pnlDoorRightA.Left = Math.Min(
                        openRightA, pnlDoorRightA.Left + 2);

                if (pnlDoorLeftA.Left == openLeftA &&
                    pnlDoorRightA.Left == openRightA)
                {
                    doorOpeningA = false;
                    doorWaitA = 0;

                    UpdateDoorLog(logIdA, "Open");
                    elevatorSubjectA.Notify("Lift A", "Door: Open");
                    lblDoorA.Text = "Door: Open";
                }
            }

            // LIFT A - WAITING
            else if (lblDoorA.Text == "Door: Open" && !doorClosingA)
            {
                doorWaitA++;

                if (doorWaitA >= 40)
                    doorClosingA = true;
            }

            // LIFT A - CLOSING
            if (doorClosingA)
            {
                if (!liftAClosingLogged)
                {
                    UpdateDoorLog(logIdA, "Closing");
                    liftAClosingLogged = true;
                }

                if (pnlDoorLeftA.Left < doorLeftAStartX)
                    pnlDoorLeftA.Left = Math.Min(
                        doorLeftAStartX, pnlDoorLeftA.Left + 2);

                if (pnlDoorRightA.Left > doorRightAStartX)
                    pnlDoorRightA.Left = Math.Max(
                        doorRightAStartX, pnlDoorRightA.Left - 2);

                if (pnlDoorLeftA.Left == doorLeftAStartX &&
                    pnlDoorRightA.Left == doorRightAStartX)
                {
                    doorClosingA = false;

                    liftAState.SetState(new IdleState());
                    liftAState.PerformAction();

                    UpdateDoorLog(logIdA, "Closed");
                    elevatorSubjectA.Notify("Lift A", "Door: Closed");

                    lblDoorA.Text = "Door: Closed";
                }
            }


            // =========================
            // LIFT B - OPENING
            // =========================

            if (doorOpeningB)
            {
                int openLeftB = doorLeftBStartX - pnlDoorLeftB.Width;
                int openRightB = doorRightBStartX + pnlDoorRightB.Width;

                if (pnlDoorLeftB.Left > openLeftB)
                    pnlDoorLeftB.Left = Math.Max(
                        openLeftB, pnlDoorLeftB.Left - 2);

                if (pnlDoorRightB.Left < openRightB)
                    pnlDoorRightB.Left = Math.Min(
                        openRightB, pnlDoorRightB.Left + 2);

                if (pnlDoorLeftB.Left == openLeftB &&
                    pnlDoorRightB.Left == openRightB)
                {
                    doorOpeningB = false;
                    doorWaitB = 0;

                    UpdateDoorLog(logIdB, "Open");
                    elevatorSubjectB.Notify("Lift B", "Door: Open");
                    lblDoorB.Text = "Door: Open";
                }
            }

            // LIFT B - WAITING
            else if (lblDoorB.Text == "Door: Open" && !doorClosingB)
            {
                doorWaitB++;

                if (doorWaitB >= 40)
                    doorClosingB = true;
            }

            // LIFT B - CLOSING
            if (doorClosingB)
            {
                if (!liftBClosingLogged)
                {
                    UpdateDoorLog(logIdB, "Closing");
                    liftBClosingLogged = true;
                }

                if (pnlDoorLeftB.Left < doorLeftBStartX)
                    pnlDoorLeftB.Left = Math.Min(
                        doorLeftBStartX, pnlDoorLeftB.Left + 2);

                if (pnlDoorRightB.Left > doorRightBStartX)
                    pnlDoorRightB.Left = Math.Max(
                        doorRightBStartX, pnlDoorRightB.Left - 2);

                if (pnlDoorLeftB.Left == doorLeftBStartX &&
                    pnlDoorRightB.Left == doorRightBStartX)
                {
                    doorClosingB = false;

                    liftBState.SetState(new IdleState());
                    liftBState.PerformAction();

                    UpdateDoorLog(logIdB, "Closed");
                    elevatorSubjectB.Notify("Lift B", "Door: Closed");

                    lblDoorB.Text = "Door: Closed";
                }
            }


            // =========================
            // STOP DOOR TIMER
            // =========================

            if (!doorOpeningA && !doorClosingA &&
                !doorOpeningB && !doorClosingB &&
                lblDoorA.Text == "Door: Closed" &&
                lblDoorB.Text == "Door: Closed")
            {
                timer2.Stop();
            }
        }

        private void btnEmergency_Click(object sender, EventArgs e)
        {
            emergencyActive = true;

            timer1.Stop();
            timer2.Stop();

            movingA = false;
            movingB = false;

            doorOpeningA = false;
            doorOpeningB = false;

            doorClosingA = false;
            doorClosingB = false;

            lblDoorA.Text = "EMERGENCY!";
            lblDoorB.Text = "EMERGENCY!";

            System.Media.SystemSounds.Exclamation.Play();

            MessageBox.Show(
                "EMERGENCY ALERT! Both elevators stopped!",
                "EMERGENCY",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Asterisk.Play();

            MessageBox.Show(
                "HELP REQUESTED!\nPlease wait. Assistance has been notified.",
                "Elevator Help",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnViewLogs_Click(object sender, EventArgs e)
        {
            LoadLogs();
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM dbo.ElevatorLogs ORDER BY LogID DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();

                da.Fill(dt);

                e.Result = dt;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("Database Error: " + e.Error.Message);
            }
            else
            {
                dgvLogs.DataSource = e.Result;
            }
        }

       
    }
}



        
           
