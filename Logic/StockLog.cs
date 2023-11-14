using Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Logic
{
    public class StockLog
    {
        StockDat objStock = new StockDat();

        public DataSet showStock()
        {
            return objStock.showStock();
        }
        public bool saveStock(string nombre,int cantidad_stock)
        {
            return objStock.saveStock(nombre,cantidad_stock);
        }
        public bool updateStock(int i_stock_id,string nombre, int i_stock_amount)
        {
            return objStock.updateStock(i_stock_id,nombre, i_stock_amount);
        }

        public bool deleteStock(int i_id)
        {
            return objStock.deleteStock(i_id);
        }

        public DataSet showStockDDL()
        {
            return objStock.showStockDDL();
        }
    }
}
    