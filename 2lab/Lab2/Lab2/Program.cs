using Lab2;


var (украинскаяЭнтропия, массивУкраинскойВероятности) = help.ЭнтропияПоШенонуДефолтыч(sources.ukranian, sources.ukranianТесть);
var (немецкаяЭнтропия, массивНемецкойВероятности) = help.ЭнтропияПоШенонуДефолтыч(sources.german, sources.germanТесть);
foreach (var item in массивУкраинскойВероятности)
{
    Console.WriteLine(item);

}
foreach (var item in массивНемецкойВероятности)
{
    Console.WriteLine(item);
}
Console.WriteLine();
Console.WriteLine(
    $"Ukranian:{украинскаяЭнтропия}\n" +
    $"German:{немецкаяЭнтропия}"
    );
Console.WriteLine(
    $"UkranianBinary:{help.ЭнтропияБинарногоПоШенонуДефолтыч(sources.binary, sources.binaryUkraineТесть)}\n" +
    $"GermanBinary:{help.ЭнтропияБинарногоПоШенонуДефолтыч(sources.binary, sources.binaryGermanТесть)}"
    );

Console.WriteLine($"Ukranian size: {украинскаяЭнтропия*sources.Iмя.Length}");
Console.WriteLine($"German size: {немецкаяЭнтропия*sources.Name.Length}");





