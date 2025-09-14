// Dimension mismatch in initialization
int[,] matrix = new int[2, 2] {
    {1, 2, 3},
    {4, 5}
};

// Jagged initialization (not rectangular)
int[,] matrix = {
    {1, 2, 3},
    {4, 5}
};

// Missing dimensions
int[,] matrix = new int[,];

// Row length inconsistency
int[,] matrix = new int[2, 3] {
    {1, 2},
    {3, 4, 5}
};