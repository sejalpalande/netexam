using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebExam.Models;

namespace WebExam.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        string ConnectionString = @"Data Source =(localdb)\MSSQLLocalDB; Initial catalog = Exam; Integrated Security = True; ";
        public ActionResult Index()
        {
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(ConnectionString))
            {
                sqlConn.Open();
                String selectQuery = "select * from Products";
                SqlDataAdapter sqDa = new SqlDataAdapter(selectQuery, sqlConn);
                sqDa.Fill(dtbl);
            }
            return View(dtbl);
        }

        

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View(new Product());
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(Product pr)
        {
            //DataTable dtbl = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(ConnectionString))
            {
                sqlConn.Open();
                String insertQuery = "insert into Products values (@ProductId, @ProductName, @Rate, @Description, @CategoryName)";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = insertQuery;

                cmd.Parameters.AddWithValue("@ProductId", pr.ProductId);
                cmd.Parameters.AddWithValue("@ProductName", pr.ProductName);
                cmd.Parameters.AddWithValue("@Rate", pr.Rate);
                cmd.Parameters.AddWithValue("@Description", pr.Description);
                cmd.Parameters.AddWithValue("@CategoryName", pr.CategoryName);

                cmd.ExecuteNonQuery();
                sqlConn.Close();
            }  
            

                return RedirectToAction("Index");
            }
            

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {

            Product pr = new Product();
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(ConnectionString))
            {
                sqlConn.Open();
                string selectQuery = "select * from Products where ProductId=@ProductId";
                SqlDataAdapter sqDa = new SqlDataAdapter(selectQuery, sqlConn);
                sqDa.SelectCommand.Parameters.AddWithValue("@ProductId", id);
                sqDa.Fill(dtbl);

                if (dtbl.Rows.Count == 1) {
                    pr.ProductId = Convert.ToInt32(dtbl.Rows[0][0].ToString());
                    pr.ProductName = dtbl.Rows[0][1].ToString();
                    pr.Rate = Convert.ToDecimal(dtbl.Rows[0][2].ToString());
                    pr.Description = dtbl.Rows[0][3].ToString();
                    pr.CategoryName = dtbl.Rows[0][4].ToString();
                    return View(pr);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
              
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
