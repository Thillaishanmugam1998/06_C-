// Declaration only
int[][] jagged;
string[][] names;

// Declaration with initialization
int[][] jagged = new int[3][];
jagged[0] = new int[] {1, 2, 3};
jagged[1] = new int[] {4, 5};
jagged[2] = new int[] {6, 7, 8, 9};

// Compact initialization
int[][] jagged = {
    new int[] {1, 2, 3},
    new int[] {4, 5},
    new int[] {6, 7, 8, 9}
};

// Declaration with outer array size
int[][] jagged = new int[3][];

// Using var keyword
var jagged = new int[][] {
    new int[] {1, 2, 3},
    new int[] {4, 5},
    new int[] {6, 7, 8, 9}
};