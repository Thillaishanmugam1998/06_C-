// Declaration only
int[] numbers;
string[] names;

// Declaration with initialization (size inferred)
int[] numbers = {1, 2, 3, 4, 5};
string[] names = {"John", "Jane", "Bob"};

// Declaration with explicit size
int[] numbers = new int[5];
string[] names = new string[3];

// Declaration with size and initialization
int[] numbers = new int[5] {1, 2, 3, 4, 5};
string[] names = new string[3] {"John", "Jane", "Bob"};

// Using var keyword
var numbers = new int[] {1, 2, 3, 4, 5};
var names = new string[3] {"John", "Jane", "Bob"};