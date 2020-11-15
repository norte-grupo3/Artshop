using ArtShop.Entities.Model;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.Data
{
    public partial class CartItemDAC : DataAccessComponent
    {
        public CartItem Create(CartItem cartItem)
        {
            const string SQL_STATEMENT =
                "INSERT INTO dbo.CartItem ([CartId], [ProductId], [Price], [Quantity]) " +
                "VALUES(@CartId, @ProductId, @Price, @Quantity); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@CartId", DbType.Int32, cartItem.CartId);
                db.AddInParameter(cmd, "@ProductId", DbType.Int32, cartItem.ProductId);
                db.AddInParameter(cmd, "@Price", DbType.Double, cartItem.Price);
                db.AddInParameter(cmd, "@Quantity", DbType.Int32, cartItem.Quantity);

                cartItem.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return cartItem;
        }

        public void UpdateById(CartItem cartItem)
        {
            const string SQL_STATEMENT =
                "UPDATE dbo.CartItem " +
                "SET " +
                    "[CartId]=@CartId, " +
                    "[ProductId]=@ProductId, " +
                    "[Price]=@Price, " +
                    "[Quantity]=@Quantity " +
                "WHERE [Id]=@Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@CartId", DbType.Int32, cartItem.CartId);
                db.AddInParameter(cmd, "@ProductId", DbType.Int32, cartItem.ProductId);
                db.AddInParameter(cmd, "@Price", DbType.Double, cartItem.Price);
                db.AddInParameter(cmd, "@Quantity", DbType.Int32, cartItem.Quantity);
                db.AddInParameter(cmd, "@Id", DbType.Int32, cartItem.Id);

                db.ExecuteNonQuery(cmd);
            }
        }


        public void DeleteById(int id)
        {
            const string SQL_STATEMENT = "DELETE dbo.CartItem " +
                                         "WHERE [Id]=@Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public CartItem SelectById(int id)
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [CartId], [ProductId], [Price], [Quantity] " +
                "FROM dbo.CartItem  " +
                "WHERE [Id]=@Id ";

            CartItem cartItem = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        cartItem = LoadCartItem(dr);
                    }
                }
            }

            return cartItem;
        }


        public List<CartItem> Select()
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [CartId], [ProductId], [Price], [Quantity] " +
                "FROM dbo.CartItem ";

            List<CartItem> result = new List<CartItem>();

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        CartItem cartItem = LoadCartItem(dr);
                        result.Add(cartItem);
                    }
                }
            }

            return result;
        }


        private CartItem LoadCartItem(IDataReader dr)
        {
            CartItem cartItem = new CartItem();

            cartItem.Id = GetDataValue<int>(dr, "Id");
            cartItem.CartId = GetDataValue<int>(dr, "CartId");
            cartItem.ProductId = GetDataValue<int>(dr, "ProductId");
            cartItem.Price = GetDataValue<double>(dr, "Price");
            cartItem.Quantity = GetDataValue<int>(dr, "Quantity");

            return cartItem;
        }
    }
}
