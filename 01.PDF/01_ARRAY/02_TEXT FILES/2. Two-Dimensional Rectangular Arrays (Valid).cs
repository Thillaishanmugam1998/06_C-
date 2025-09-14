// Declaration only
int[,] matrix;
string[,] grid;

// Declaration with initialization (size inferred)
int[,] matrix = {
    {1, 2, 3},
    {4, 5, 6},
    {7, 8, 9}
};

// Declaration with explicit dimensions
int[,] matrix = new int[3, 3];
string[,] grid = new string[2, 4];

// Declaration with dimensions and initialization
int[,] matrix = new int[2, 3] {
    {1, 2, 3},
    {4, 5, 6}
};

// Using var keyword
var matrix = new int[,] {
    {1, 2, 3},
    {4, 5, 6}
};