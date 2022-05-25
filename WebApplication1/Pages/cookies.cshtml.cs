using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace WebApplication1.Pages.Shared
{
    public class IndexModel : PageModel
    {
        public List<CookiesInfo> ListCookies = new List<CookiesInfo>();
        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=DESKTOP-A2HVK1H;Initial Catalog=cookies;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM T_Catalogue";
                    using (SqlCommand command = new SqlCommand(sql, connection)) 
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CookiesInfo cookiesInfo = new CookiesInfo();
                                cookiesInfo.ref_ID = reader.GetInt32(0);
                                cookiesInfo.name = reader.GetString(1);
                                cookiesInfo.description = reader.GetString(2);

                                ListCookies.Add(cookiesInfo);
                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }
    }

    public class CookiesInfo
    {
        public int ref_ID;
        public string? name;
        public string? description;
    }
}
