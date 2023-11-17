using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;

namespace WebApplication8
{
    public partial class Grilla : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["usuario"] != null)
            {
                loadGrid();
            }
            else
            {
                Response.Redirect("FormularioDeRegistro.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string path = $"{Server.MapPath(".")}/{Session["usuario"]}";
            string mensaje = string.Empty;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (HttpPostedFile archivo in FileUpload1.PostedFiles)
            {
                if (File.Exists($"{path}/{archivo.FileName}"))
                {
                    mensaje += $"El archivo: {archivo.FileName} ya existe.";
                }
                else
                {
                    FileUpload1.SaveAs($"{path}/{archivo.FileName}");
                }
                Label1.Text = mensaje;
            }
            loadGrid();
        }

        public void loadGrid()
        {
            string path = $"{Server.MapPath(".")}/{Session["usuario"]}";

            if (Directory.Exists(path))
            {
                string[] files = Directory.GetFiles(path);
                List<Carpetas> fileList = new List<Carpetas>();
                foreach (string file in files)
                {
                    var filenew = new Carpetas(Path.GetFileName(file), file);
                    fileList.Add(filenew);
                }
                GridView1.DataSource = fileList;
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Descargar")
            {
                GridViewRow registro = GridView1.Rows[Convert.ToInt32(e.CommandArgument)];
                string filePath = registro.Cells[2].Text;

                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                Response.TransmitFile(filePath);
                Response.End();
            }
        }
    }
}