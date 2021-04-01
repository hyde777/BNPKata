using BNPKata;
using BNPKataConsole;

string inputFile = args[0];
string outputFile = args[1];

ITravelControler travelControlerControler = new TravelControler(new Travel(Factory.Zones()), new JsonTapDeserializer(), new JsonJourneySerializer(), new FilePrinter());
travelControlerControler.Price(inputFile, outputFile);