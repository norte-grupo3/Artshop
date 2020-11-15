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
   public partial class ProductDAC: DataAccessComponent
    {
        public Product Create(Product product)
        {
            const string SQL_STATEMENT =
                "INSERT INTO dbo.Product ([Title], [Description], [Image], [Price],[ArtistId]) " +
                "VALUES(@Title, @Description, @Image, @Price, @ArtistId); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Title", DbType.String, product.Title);
                db.AddInParameter(cmd, "@Description", DbType.String, product.Description);
                db.AddInParameter(cmd, "@Image", DbType.String, product.Image);
                db.AddInParameter(cmd, "@Price", DbType.Double, product.Price);
                db.AddInParameter(cmd, "@ArtistId", DbType.Int32, product.Artist.Id);

                product.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return product;
        }

        public List<Product> Select()
        {
            const string SQL_STATEMENT =
                "SELECT [Id],[Title], [Description], [Image], [Price],[ArtistId] " +
                "FROM dbo.Product ";

            List<Product> result = new List<Product>();

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Product product = LoadProduct(dr);
                        result.Add(product);
                    }
                }
            }

            return result;
        }


        private Product LoadProduct(IDataReader dr)
        {
            Product product = new Product();

            product.Id = GetDataValue<int>(dr, "Id");
            product.Title = GetDataValue<string>(dr, "Title");
            product.Description = GetDataValue<string>(dr, "Description");
            product.Image = GetDataValue<string>(dr, "Image");
            product.Price = GetDataValue<double>(dr, "Price");


            return product;
        }
    }
}
