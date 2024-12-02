// See https://aka.ms/new-console-template for more information

using MyMiniPOS_Backend.FakeDataGenerator;

bool isContinue = true;

while (isContinue)
{
	Console.Write("> ");
	string[] input = Console.ReadLine()!.Split(' ');

	string cmd = input[0];
	int count = int.Parse(input[1]);

	switch (cmd)
	{
		case "product":
			var model = Generator.GenerateProduct(count);
			Console.WriteLine("-------------------------");
			Console.WriteLine("Inserted: " + model.InsertedCount);
			Console.WriteLine("Failed: " + model.FailedCount);
			Console.WriteLine("-------------------------");
			break;

		case "stop":
			isContinue = false;
			break;
	}
}