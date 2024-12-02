using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMiniPOS_Backend.FakeDataGenerator;

internal class Generator
{
	private static readonly SqlConnectionStringBuilder _SqlConnectionStringBuilder = new()
	{
		DataSource = ".",
		InitialCatalog = "MyMiniPOSDB",
		UserID = "sa",
		Password = "Aa145156167!",
		TrustServerCertificate = true
	};

	private static string CreateRandomString(int min, int max)
	{
		Random rand = new Random();

		// Choosing the size of string 
		// Using Next() string 
		int stringlen = rand.Next(min, max);
		int randValue;
		string str = "";
		char letter;
		for (int i = 0; i < stringlen; i++)
		{

			// Generating a random number. 
			randValue = rand.Next(0, 26);

			// Generating random character by converting 
			// the random number into character. 
			letter = Convert.ToChar(randValue + 65);

			// Appending the letter to string. 
			str = str + letter;
		}

		return str;
	}

	private static decimal CreateRandomDecimal(int min, int max)
	{
		Random rand = new Random();

		int num = rand.Next(min, max);

		return (decimal)num;
	}

	private static int CreateRandomInt(int min, int max)
	{
		Random rand = new Random();

		int num = rand.Next(min, max);

		return num;
	}

	public static GenerateReturnModel GenerateProduct(int count)
	{
		string connectionString = _SqlConnectionStringBuilder.ConnectionString;
		using IDbConnection connection = new SqlConnection(connectionString);

		int insertedCount = default;
		int failedCount = default;

		#region Insert loop
		for (int i = 0; i < count; i++)
		{
			string query = @"INSERT INTO [dbo].[TBL_Product]
           ([ProductName]
           ,[ProductImageUrl]
           ,[ProductCategoryId]
           ,[ProductPrice]
           ,[ProductDiscountRate])
     VALUES
           (@ProductName
           ,@ProductImageUrl
           ,@ProductCategoryId
           ,@ProductPrice
           ,@ProductDiscountRate)";

			var variables = new
			{
				ProductName = CreateRandomString(6, 10),
				ProductImageUrl = CreateRandomString(6, 10),
				ProductCategoryId = CreateRandomString(36, 36),
				ProductPrice = CreateRandomDecimal(1, 99) * 100,
				ProductDiscountRate = CreateRandomDecimal(1, 10)
			};

			int result = connection.Execute(query, variables);

			if (result == 0)
			{
				failedCount++;
				continue;
			}

			insertedCount++;
		}
		#endregion

		GenerateReturnModel returnModel = new()
		{
			InsertedCount = insertedCount,
			FailedCount = failedCount
		};

		return returnModel;
	}
}

class GenerateReturnModel
{
	public int InsertedCount { get; set; }
	public int FailedCount { get; set; }
}