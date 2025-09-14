// Trying to initialize inner arrays without proper syntax
int[][] jagged;
jagged = {{1, 2}, {3, 4, 5}};

// Accessing uninitialized inner arrays
int[][] jagged = new int[3][];
int value = jagged[0][0];

// Invalid nested array size specification
int[][] jagged = new int[3][3];

// Missing inner array initialization
int[][] jagged = new int[3][];
jagged[0] = {1, 2, 3};

// Type mismatch in inner arrays
int[][] jagged = {
    new int[] {1, 2, 3},
    new string[] {"a", "b"}
};