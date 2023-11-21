using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment4.InstructorsKR
{
    public partial class instructorpage : System.Web.UI.Page
    {
        KarateDataContext _dbcon;
        string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\aesch\\OneDrive\\Documents\\GitHub\\Assignment4_Team\\Assignment4\\App_Data\\KarateSchool(1).mdf;Integrated Security=True;Connect Timeout=30";
        protected void Page_Load(object sender, EventArgs e)
        {
            // string myUser=User.Identity.Name;
            string myUser = "user2";










        }
    }
}