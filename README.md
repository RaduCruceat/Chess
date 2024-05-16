# Chess Game

A C# Windows Forms application for playing Chess locally or online agains another player.


## Features

- Local Play: Play against another person on the same computer.
- Online Play: Connect and play with another player over the internet.
- User-Friendly Interface: Intuitive and easy-to-use graphical interface.
- Timer: Each player has a limited time to make their moves.


## Technologies Used

- Programming Language: C#
- Framework: .NET Framework
- UI: Windows Forms
- Networking: TCP/IP Sockets
 
## Game Rules

#### Objective: 
- Checkmate your opponent's king.
#### Setup:
- Place pieces on a square board.
#### Piece Movement:
- King moves one square in any direction.
- Queen moves any number of squares horizontally, vertically, or diagonally.
- Rooks move any number of squares horizontally or vertically.
- Bishops move any number of squares diagonally.
- Knights move in an "L" shape.
- Pawns move forward one square, capture diagonally.
#### Special Moves:
- Castling: King moves two squares towards rook, rook moves next to king.
- En passant: Special pawn capture after double-step move.
- Pawn promotion: Pawn reaching opposite end promotes to another piece.
#### Check and Checkmate:
- Check: King under threat.
- Checkmate: King in check with no legal move to escape.
#### Draw:
- Stalemate: Player to move has no legal moves, not in check.
- Other draw scenarios: Insufficient material, fifty-move rule, threefold repetition, or agreement between players.


<img src="https://github.com/RaduCruceat/Chess/blob/master/Resources/TablaSahScreen.png" alt="Game Board">
