using Controllers;

Console.WriteLine("Inicio...");

if (new ReadAndPersistController().Recuperar())
{
    Console.WriteLine("Recuperado!!!!");
}
else
{
    Console.WriteLine("ERRO");
}