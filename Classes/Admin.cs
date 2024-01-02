using System.Security.Cryptography.X509Certificates;

namespace Itec102.StudentManagementSystem
{
    public class AdminOption
    {
        public static void Enrolled()
        {
            string[] sectionChoices = new string[] { "All", "BSCS 1-A", "BSCS 1-B" };

            string sectionMessage = "View currently enrolled students";
            string sectionStatus = "Logout";

            string adminState = "Login";

            var Menu = new Menu(sectionChoices, sectionMessage, sectionStatus);
            int indexChoices = Menu.SectionMenu(adminState);

            Choice.Set(sectionChoices[indexChoices]);
            Csv.LoadUsers(Choice.Get());

            string[] adminChoices = new string[] { "View again", "Back", "Logout"};

            string adminMessage = "Choose an option:";
            string adminStatus = "Logout";

            var AdminMenu = new Menu(adminChoices, adminMessage, adminStatus);

            int adminChoice = AdminMenu.AdminMenu(adminState);
            string adminSelectedChoice = adminChoices[adminChoice];

            if (adminSelectedChoice == "View again")
            {
                Enrolled();
            }

            else if (adminSelectedChoice == "Back")
            {
                Views.Admin();
            }
            else
            {
                Message.LogoutSuccess();
                Console.ReadKey();
                Application.Run();
            }
        } 

        public static void Pending()
        {
            int count = 0;

            string[] lines = File.ReadAllLines("data/users.csv");
            
            foreach (var line in lines)
            {
                string[] fields = line.Split(',');

                string role = fields[5].Trim();

                if (role == "admin")
                {
                    continue;
                }

                string firstname = fields[1].Trim();
                string lastname = fields[2].Trim();
                string email = fields[3].Trim();
                string year = fields[6].Trim();
                string course = fields[7].Trim();
                string section = fields[8].Trim();
                string status = fields[9].Trim();

                if (status == "pending")
                {
                    count += 1;
                    string[] adminPendingChoices = new string[] { "Accept", "Reject"};

                    string adminPendingMessage = $"PENDING ENROLLMENTS ({count} of 3 Pending)";
                    string adminStatus = "Logout";

                    var adminPendingMenu = new Menu(adminPendingChoices, adminPendingMessage, adminStatus);
                    int adminPendingIndex = adminPendingMenu.PendingMenu(firstname, lastname, year, course, section, email);

                    switch (adminPendingChoices[adminPendingIndex])
                    {
                        case "Accept":
                        Console.WriteLine("Accepted");
                        break;

                        case "Reject":
                        Console.WriteLine("Rejected");
                        break;
                    }
                }

                else
                {
                    continue;
                }

            }
        }
    }
}