using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtShop.Entities.Model;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;

namespace ArtShop.Data
{
    public class OrderDetailDAC : DataAccessComponent
    {
        public OrderDetail Create(OrderDetail item)

        {
            const string SQL_STATEMENT = "insert into [dbo].[OrderDetailDetail] (OrderId,ProductId,Price,Quantity) values (@OrderId,@ProductId,@Price,@Quiantity)";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@OrderId", DbType.String, item.OrderId);
                db.AddInParameter(cmd, "@ProductId", DbType.DateTime, item.ProductId);
                db.AddInParameter(cmd, "@Price", DbType.Double, item.Price);
                db.AddInParameter(cmd, "@Quantity", DbType.Int32, item.Quantity);


                item.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return item;

        }

        public List<OrderDetail> Select()
        {
            const string SQL_STATEMENT = "SELECT [Id],[OrderId],[ProductId],[Price],[Quantity] FROM[dbo].[OrderDetail]";

        List<OrderDetail> result = new List<OrderDetail>();

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        OrderDetail item = LoadOrderDetail(dr);
                        result.Add(item);
                    }
                }
            }

            return result;
        }

        public void DeleteById(int id)
        {
            const string SQL_STATEMENT = "delete from [dbo].[OrderDetail] where Id=@id";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public OrderDetail SelectById(int id)
        {
            const string SQL_STATEMENT = "SELECT SELECT [Id],[OrderId],[ProductId],[Price],[Quantity] FROM [dbo].[OrderDetail] where Id=@id";

            OrderDetail item = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        item = LoadOrderDetail(dr);
                    }
                }
            }

            return item;
        }

        public OrderDetail UpdateById(OrderDetail item)
        {
            const string SQL_STATEMENT = "update OrderDetail set OrderId = @OrderId,ProductId = @ProductId,Price = @Price,Quantity = @Quantity where [dbo].[OrderDetail].Id = @Id";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@OrderId", DbType.String, item.OrderId);
                db.AddInParameter(cmd, "@ProductId", DbType.DateTime, item.ProductId);
                db.AddInParameter(cmd, "@Price", DbType.Double, item.Price);
                db.AddInParameter(cmd, "@Quantity", DbType.Int32, item.Quantity);
                db.AddInParameter(cmd, "@Id", DbType.Int32, item.Id);

                db.ExecuteNonQuery(cmd);
            }

            return item;
        }
        private OrderDetail LoadOrderDetail(IDataReader dr)
        {
            OrderDetail item = new OrderDetail();

            item.Id = GetDataValue<int>(dr, "Id");
            item.OrderId = GetDataValue<int>(dr, "OrderId");
            item.ProductId = GetDataValue<int>(dr, "ProductId");
            item.Price = GetDataValue<double>(dr, "Price");
            item.Quantity = GetDataValue<int>(dr, "Quantity");


            return item;
        }
    }
}
