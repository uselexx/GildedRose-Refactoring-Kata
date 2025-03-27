# Gilded Rose
Team: Breakout Room 3
Members: Alexander Wedenik & Bilaver Matilda

## Design Decisions

The Gilded Rose application is designed to manage the inventory of a store. The main design decisions include:

1. **Single Responsibility Principle**: Each class has a single responsibility. The `GildedRose` class is responsible for updating the quality of items, while the `Item` class represents the items in the inventory.

2. **Open/Closed Principle**: The design allows for easy extension of new item types without modifying the existing code. This is achieved by using inheritance and polymorphism.

3. **Strategy Pattern / Abstract Class**: Different types of items have different behaviors when their quality is updated. The strategy pattern (in Level 2) and later an abstract base class is used to encapsulate these behaviors in separate classes.

4. **Test-Driven Development (TDD)**: The project includes a comprehensive suite of unit tests to ensure the correctness of the code.

## Patterns Used

1. **Strategy Pattern**: This pattern is used to define a family of algorithms (update quality behaviors), encapsulate each one, and make them interchangeable. The `GildedRose` class uses this pattern to delegate the quality update logic to the appropriate strategy class.

2. **Factory Pattern**: A factory class is used to create instances of different item types based on the item name. This helps in decoupling the item creation logic from the `GildedRose` class.

3. **Abstract Base Class**: An abstract base class is used to define the common behavior of all items. This allows for code reuse and ensures that all item types adhere to the same interface.

4.	**Observer Pattern**: The observer pattern is used to notify the `GildedRoseItemObserv	er` when the item sellIn gets lower than 3. This allows for timely actions to be taken when an item is about to expire.

## Complexities

1. **Time Complexity**: The `UpdateQuality` method iterates through the list of items once, making the time complexity O(n), where n is the number of items.

2. **Space Complexity**: The space complexity is O(1) as the method uses a constant amount of extra space regardless of the number of items.

3. **Extensibility**: The design is highly extensible, allowing new item types to be added with minimal changes to the existing codebase. This is achieved through the use of design patterns and adherence to SOLID principles.

## Intentions
When we started the project we focused on using the patterns instructed by the level in a way that could benefit the application.
The main focus was not to keep the code as clean as possible, but to make it as easy as possible to add new items and new rules to the application. 
The main reason for that is that the code base is so small that it is not worth to keep it clean, but to make it easy to add new features. And introducing
a new sophisticated folder structure and one class per file would make the code harder to understand, and also lead to us having less time to focus on
using the design patterns in a way that would benefit the application.
The hardest level by far was the first level, since you had to get familiar with the requirements and the code base. The second level was easier, since we
already had a good understanding of the code base and the requirements. The third level was the easiest, since we had already implemented the strategy pattern
and the factory pattern.
What was really important was to develop the tests first, to ensure the application behaved as expected. This was the thing that saved us the most time, since
we could refactor the code without worrying about breaking the application.