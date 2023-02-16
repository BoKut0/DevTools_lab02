using Wintellect.PowerCollections;

Wintellect.PowerCollections.Stack<int> test = new();
Console.WriteLine("Размер стека:" + test.Capacity);

test.Push(15);
test.Push(25);

Console.WriteLine("Работа метода top:" + test.Top());
Console.WriteLine("Работа метода pop:" + test.Pop());