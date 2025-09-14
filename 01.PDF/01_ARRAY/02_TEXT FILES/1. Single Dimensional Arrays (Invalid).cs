// Size mismatch between declaration and initialization
int[] numbers = new int[3] {1, 2, 3, 4, 5};

// Missing size when required
int[] numbers = new int[];

// Using array initializer without new keyword in assignment
int[] numbers;
numbers = {1, 2, 3};

// Invalid mixed types without proper casting
int[] numbers = {1, "2", 3};