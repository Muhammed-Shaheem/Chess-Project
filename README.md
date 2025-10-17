# ♟️ Chess Game (WPF .NET)

A complete **Chess Game** built using **C# and WPF (.NET)**.  
This project focuses on clean logic, smooth visuals, and a modular design — perfect for learning or showcasing .NET desktop app development skills.

---

## 🚀 Features

- ✅ **Fully Functional Chess Rules** — legal moves, check, checkmate, stalemate, and pawn promotion.  
- ✅ **Interactive Board UI** — click on a piece to see valid moves.  
- ✅ **Piece Highlighting** — highlights possible moves using color backgrounds.  
- ✅ **Sound Effects** — play, capture, and notification sounds.  
- ✅ **Customizable Board** — supports RGB colors and themes.  
- ✅ **Expandable Design** — structure ready for AI or multiplayer mode.

---

## 🧰 Tech Stack

| Category | Technology |
|-----------|-------------|
| Language | C# |
| Framework | .NET WPF |
| UI | XAML |

---

## 🧠 How It Works

1. Each chess piece (Pawn, Rook, Knight, etc.) is represented by a class.  
2. Each piece knows how it can move on the board.  
3. The **Game Board** (Grid in XAML) is connected to the backend logic via event handlers.  
4. When a user clicks:
   - The system identifies the piece.
   - Calculates valid moves.
   - Highlights all legal move squares.
5. On the next click, the move is executed and the board updates.

---


