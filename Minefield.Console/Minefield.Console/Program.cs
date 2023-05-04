using Minefield.Core;

var game = new GameOrchestrator(
    new Field(5, 10),
    new Player(5)
);

game.Start();