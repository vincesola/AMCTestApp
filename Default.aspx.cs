using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace AMCTestApp
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            //string sql = "SELECT * FROM SupplierInformation WHERE EffectiveEndDateTime > GETDATE()";
            string sql = "SELECT TOP(10) * FROM[AMCWebSite].[amcwebintegration].[AuditJobControl] WITH (NOLOCK)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            GridView1.DataSource = reader;
            GridView1.DataBind();

            conn.Close();
        }
    }
}