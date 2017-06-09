using BasesDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AppQRAPI.Models
{
    public class Book
    {
        public string Sku { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Editorial { get; set; }
        public int Year { get; set; }
        public string ISBN { get; set; }
        public int Pages { get; set; }
        public string Synopsis { get; set; }
        public double Price { get; set; }
        public string UrlCover { get; set; }
        public string UrlPDF { get; set; }

        public Book (string sku)
        {
            BaseDatos bd = null;
            DataSet ds;
            bool bNewConnection = true;

            try
            {
                if (String.IsNullOrEmpty(sku))
                    throw new Exception("SKU received can not be blank");

                bNewConnection = BaseDatos.preparaBD(System.Configuration.ConfigurationManager.ConnectionStrings["azurebbdd"].ConnectionString, BaseDatos.Tipos.SqlServer, ref bd, null);

                ds = bd.ExecuteDataSet("SELECT * FROM BOOKS WHERE SKU = '" + sku + "'");

                // TABLE PRODUCTS
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        this.Sku = sku;
                        this.Title = dr["TITLE"].ToString();
                        this.Author = dr["AUTHOR"].ToString();
                        this.Editorial = dr["EDITORIAL"].ToString();
                        this.Year = dr["YEAR"].ToString();
                        this.ISBN = dr["ISBN"].ToString();
                        this.Pages = dr["PAGES"].ToString();
                        this.Synopsis = dr["SYNOPSIS"].ToString();
                        this.Price = dr["PRICE"].ToString();
                        this.UrlCover = dr["URLCOVER"].ToString();
                        this.UrlPDF = dr["URLPDF"].ToString();
                    }
                else
                    return;

                //Cerramos la conexión usada sólo cuando la hayamos iniciado aquí.
                if (bNewConnection)
                {
                    bd.cerrarConexion();
                    bd = null;
                }
                ds = null;
            }
            catch (Exception ex)
            {
                //Liberamos siempre que la conexión se haya iniciado aquí.
                if (bNewConnection && bd != null)
                {
                    bd.cerrarConexion();
                    bd = null;
                }
                ds = null;

                //Error de por qué no puede realizar el proceso.
                throw new Exception("Error loading book info. Detail: " + ex.Message);
            }
        }

        public static string getProductJSONFromSKU(string sku)
        {
            BaseDatos bd = null;
            DataSet ds;
            bool bNewConnection = true;

            try
            {
                string sJSONResponse = "";

                if (String.IsNullOrEmpty(sku))
                    throw new Exception("SKU received can not be empty.");

                bNewConnection = BaseDatos.preparaBD(System.Configuration.ConfigurationManager.
    ConnectionStrings["azurebbdd"].ConnectionString, BaseDatos.Tipos.SqlServer, ref bd, null);

                return "CONEXIÓN ESTABLECIDA";

                ds = bd.ExecuteDataSet("SELECT * FROM BOOKS WHERE SKU = '" + sku + "'");

                //Recorremos el DataSet obtenido.
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        //Utilidades.dameValor(dr["RECURSO"], ref recurso, false, "");
                        //Utilidades.dameValor(dr["REQUIERE_CONTACTOS_DIRECCIONES"], ref bRequiereContactosYDirecciones, false, false);
                        //Utilidades.dameValor(dr["REQUIERE_SALDOS_NO_FACTURADOS"], ref bRequiereSaldosNoFacturados, false, false);
                        //Utilidades.dameValor(dr["VISTA_SNF"], ref bObtenerVistaSNF, false, false);
                        //Utilidades.dameValor(dr["TRATA_EFECTOS"], ref bTratamientoEfectos, false, false);
                        //Utilidades.dameValor(dr["USAR_NET_HTTP"], ref bUsarNetHTTP, false, false);
                        //Utilidades.dameValor(dr["TIMEOUT"], ref iTimeOut, false, 0);
                        //Utilidades.dameValor(dr["PUERTO"], ref iPuerto, false, 0);
                        //Utilidades.dameValor(dr["DIRECCION"], ref sDireccion, false, "");
                    }

                //Cerramos la conexión usada sólo cuando la hayamos iniciado aquí.
                if (bNewConnection)
                {
                    bd.cerrarConexion();
                    bd = null;
                }
                ds = null;


                return sJSONResponse;
            }
            catch (Exception ex)
            {
                //Liberamos siempre que la conexión se haya iniciado aquí.
                if (bNewConnection && bd != null)
                {
                    bd.cerrarConexion();
                    bd = null;
                }
                ds = null;

                //Error de por qué no puede realizar el proceso.
                throw new Exception("Error loading product info. Detail: " + ex.Message);
            }
        }
    }
}