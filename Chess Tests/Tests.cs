using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace Chess_Tests
{
    [TestClass]
    public class TestsFor960Algo
    {
        public int GetEmptyColumns()
        {
            int count = 0;
            foreach (var space in Row)
                if (space.piece == Piece.None) count++;

            return count;
        }

        private enum Piece { None, Bishop, Knight, Rook, King, Queen }
        private enum Color { White, Black }
        private struct Space
        {
            public Space(Piece piece, Color color)
            {
                this.piece = piece;
                this.color = color;
            }

            public Piece piece;
            public Color color;
        }

        private Space[] Row = new Space[] {
            new Space(Piece.None,Color.White),
            new Space(Piece.None,Color.Black),
            new Space(Piece.None,Color.White),
            new Space(Piece.None,Color.Black),
            new Space(Piece.None,Color.White),
            new Space(Piece.None,Color.Black),
            new Space(Piece.None,Color.White),
            new Space(Piece.None,Color.Black),
        };

        private void SetPiece(Piece piece, int column)
        {
            Row[column].piece = piece;
        }

        private bool GetPiece(Piece piece)
        {
            foreach (var space in Row)
                if (space.piece == piece) return true;

            return false;
        }

        private bool GetPieces(Piece piece, int count = 1)
        {
            if (count < 0) return false;

            int piecesFound = 0;

            foreach (var space in Row)
            {
                if (space.piece == piece)
                {
                    piecesFound++;
                }
            }

            return piecesFound == count;
        }

        private bool GetPieceOnColor(Piece piece, Color color)
        {
            foreach (var space in Row)
                if (space.piece == piece && space.color == color) return true;

            return false;
        }

        Random rand = new Random(Guid.NewGuid().GetHashCode());

        // Each test checks a section of the 960 algorithm, appending on the new section.
        // I had to write these this way because tests do not do data persistence.

        [TestMethod]
        public void Check960AlgoPlaceWhiteBishop()
        {
            // Set First Bishop
            int col = 0;
            bool isValidSet = false;
            do
            {
                col = rand.Next(0, 8);
                isValidSet = col % 2 == 0 && Row[col].piece == Piece.None;
            }
            while (!isValidSet);

            SetPiece(Piece.Bishop, col);

            Assert.IsTrue(GetPieceOnColor(Piece.Bishop,Color.White));
        }

        [TestMethod]
        public void Check960AlgoPlaceBlackBishop()
        {
            // Set First Bishop
            int col = 0;
            bool isValidSet = false;
            do
            {
                col = rand.Next(0, 8);
                isValidSet = col % 2 == 0 && Row[col].piece == Piece.None;
            }
            while (!isValidSet);

            SetPiece(Piece.Bishop, col);

            // Set Second Bishop
            col = 0;
            isValidSet = false;
            do
            {
                col = rand.Next(0, 8);
                isValidSet = col % 2 == 1 && Row[col].piece == Piece.None;
            }
            while (!isValidSet);

            SetPiece(Piece.Bishop, col);

            Assert.IsTrue(GetPieceOnColor(Piece.Bishop, Color.Black));
        }

        [TestMethod]
        public void Check960AlgoPlaceQueen()
        {
            // Set First Bishop
            int col = 0;
            bool isValidSet = false;
            do
            {
                col = rand.Next(0, 8);
                isValidSet = col % 2 == 0 && Row[col].piece == Piece.None;
            }
            while (!isValidSet);

            SetPiece(Piece.Bishop, col);

            // Set Second Bishop
            col = 0;
            isValidSet = false;
            do
            {
                col = rand.Next(0, 8);
                isValidSet = col % 2 == 1 && Row[col].piece == Piece.None;
            }
            while (!isValidSet);

            SetPiece(Piece.Bishop, col);

            // Set Queen
            isValidSet = false;
            col = 0;
            do
            {
                col = rand.Next(0, 8);
                isValidSet = Row[col].piece == Piece.None;
            }
            while (!isValidSet);

            SetPiece(Piece.Queen, col);
            
            Assert.IsTrue(GetPiece(Piece.Queen));
        }

        [TestMethod]
        public void Check960AlgoPlaceKnights()
        {
            // Set First Bishop
            int col = 0;
            bool isValidSet = false;
            do
            {
                col = rand.Next(0, 8);
                isValidSet = col % 2 == 0 && Row[col].piece == Piece.None;
            }
            while (!isValidSet);

            SetPiece(Piece.Bishop, col);

            // Set Second Bishop
            col = 0;
            isValidSet = false;
            do
            {
                col = rand.Next(0, 8);
                isValidSet = col % 2 == 1 && Row[col].piece == Piece.None;
            }
            while (!isValidSet);

            SetPiece(Piece.Bishop, col);

            // Set Queen
            isValidSet = false;
            col = 0;
            do
            {
                col = rand.Next(0, 8);
                isValidSet = Row[col].piece == Piece.None;
            }
            while (!isValidSet);

            SetPiece(Piece.Queen, col);

            // Set Knights
            isValidSet = false;
            col = 0;

            for (int i = 0; i < 2; i++)
            {
                do
                {
                    col = rand.Next(0, 8);
                    isValidSet = Row[col].piece == Piece.None;
                }
                while (!isValidSet);

                SetPiece(Piece.Knight, col);
            }

            Assert.IsTrue(GetPieces(Piece.Knight, 2));
        }

        int rookIndex1 = 0;
        int rookIndex2 = 0;
        int kingIndex = 0;

        [TestMethod]
        public void Check960AlgoPlaceRooksAndKingOrder()
        {
            // Set First Bishop
            int col = 0;
            bool isValidSet = false;
            do
            {
                col = rand.Next(0, 8);
                isValidSet = col % 2 == 0 && Row[col].piece == Piece.None;
            }
            while (!isValidSet);

            SetPiece(Piece.Bishop, col);

            // Set Second Bishop
            col = 0;
            isValidSet = false;
            do
            {
                col = rand.Next(0, 8);
                isValidSet = col % 2 == 1 && Row[col].piece == Piece.None;
            }
            while (!isValidSet);

            SetPiece(Piece.Bishop, col);

            // Set Queen
            isValidSet = false;
            col = 0;
            do
            {
                col = rand.Next(0, 8);
                isValidSet = Row[col].piece == Piece.None;
            }
            while (!isValidSet);

            SetPiece(Piece.Queen, col);

            // Set Knights
            isValidSet = false;
            col = 0;

            for (int i = 0; i < 2; i++)
            {
                do
                {
                    col = rand.Next(0, 8);
                    isValidSet = Row[col].piece == Piece.None;
                }
                while (!isValidSet);

                SetPiece(Piece.Knight, col);
            }

            int piecesLeft = 0;

            rookIndex1 = 0;
            rookIndex2 = 0;
            kingIndex = 0;

            for (int index = 0; index < Row.Length; index++)
            {
                if (Row[index].piece == Piece.None)
                {
                    if (piecesLeft == 1)
                    {
                        kingIndex = index;
                        piecesLeft++;
                    }
                    else
                    {
                        if (piecesLeft == 0)
                        {
                            rookIndex1 = index;
                            piecesLeft++;
                        }
                        else
                            rookIndex2 = index;                        
                    }
                }
            }

            Assert.IsTrue(rookIndex1 < kingIndex && kingIndex < rookIndex2);
        }

        [TestMethod]
        public void Check960AlgoRooksExist()
        {
            // Set First Bishop
            int col = 0;
            bool isValidSet = false;
            do
            {
                col = rand.Next(0, 8);
                isValidSet = col % 2 == 0 && Row[col].piece == Piece.None;
            }
            while (!isValidSet);

            SetPiece(Piece.Bishop, col);

            // Set Second Bishop
            col = 0;
            isValidSet = false;
            do
            {
                col = rand.Next(0, 8);
                isValidSet = col % 2 == 1 && Row[col].piece == Piece.None;
            }
            while (!isValidSet);

            SetPiece(Piece.Bishop, col);

            // Set Queen
            isValidSet = false;
            col = 0;
            do
            {
                col = rand.Next(0, 8);
                isValidSet = Row[col].piece == Piece.None;
            }
            while (!isValidSet);

            SetPiece(Piece.Queen, col);

            // Set Knights
            isValidSet = false;
            col = 0;

            for (int i = 0; i < 2; i++)
            {
                do
                {
                    col = rand.Next(0, 8);
                    isValidSet = Row[col].piece == Piece.None;
                }
                while (!isValidSet);

                SetPiece(Piece.Knight, col);
            }

            int piecesLeft = 0;

            rookIndex1 = 0;
            rookIndex2 = 0;
            kingIndex = 0;

            for (int index = 0; index < Row.Length; index++)
            {
                if (Row[index].piece == Piece.None)
                {
                    if (piecesLeft == 1)
                    {
                        kingIndex = index;
                        piecesLeft++;
                    }
                    else
                    {
                        if (piecesLeft == 0)
                        {
                            rookIndex1 = index;
                            piecesLeft++;
                        }
                        else
                            rookIndex2 = index;
                    }
                }
            }

            SetPiece(Piece.Rook, rookIndex1);
            SetPiece(Piece.Rook, rookIndex2);

            Assert.IsTrue(GetPieces(Piece.Rook, 2));
        }

        [TestMethod]
        public void Check960AlgoKingExists()
        {
            // Set First Bishop
            int col = 0;
            bool isValidSet = false;
            do
            {
                col = rand.Next(0, 8);
                isValidSet = col % 2 == 0 && Row[col].piece == Piece.None;
            }
            while (!isValidSet);

            SetPiece(Piece.Bishop, col);

            // Set Second Bishop
            col = 0;
            isValidSet = false;
            do
            {
                col = rand.Next(0, 8);
                isValidSet = col % 2 == 1 && Row[col].piece == Piece.None;
            }
            while (!isValidSet);

            SetPiece(Piece.Bishop, col);

            // Set Queen
            isValidSet = false;
            col = 0;
            do
            {
                col = rand.Next(0, 8);
                isValidSet = Row[col].piece == Piece.None;
            }
            while (!isValidSet);

            SetPiece(Piece.Queen, col);

            // Set Knights
            isValidSet = false;
            col = 0;

            for (int i = 0; i < 2; i++)
            {
                do
                {
                    col = rand.Next(0, 8);
                    isValidSet = Row[col].piece == Piece.None;
                }
                while (!isValidSet);

                SetPiece(Piece.Knight, col);
            }

            int piecesLeft = 0;

            rookIndex1 = 0;
            rookIndex2 = 0;
            kingIndex = 0;

            for (int index = 0; index < Row.Length; index++)
            {
                if (Row[index].piece == Piece.None)
                {
                    if (piecesLeft == 1)
                    {
                        kingIndex = index;
                        piecesLeft++;
                    }
                    else
                    {
                        if (piecesLeft == 0)
                        {
                            rookIndex1 = index;
                            piecesLeft++;
                        }
                        else
                            rookIndex2 = index;
                    }
                }
            }

            SetPiece(Piece.Rook, rookIndex1);
            SetPiece(Piece.Rook, rookIndex2);

            SetPiece(Piece.King, kingIndex);
            Assert.IsTrue(GetPiece(Piece.King));
        }

        [TestMethod]
        public void CheckRowIsPopulated()
        {
            // Set First Bishop
            int col = 0;
            bool isValidSet = false;
            do
            {
                col = rand.Next(0, 8);
                isValidSet = col % 2 == 0 && Row[col].piece == Piece.None;
            }
            while (!isValidSet);

            SetPiece(Piece.Bishop, col);

            // Set Second Bishop
            col = 0;
            isValidSet = false;
            do
            {
                col = rand.Next(0, 8);
                isValidSet = col % 2 == 1 && Row[col].piece == Piece.None;
            }
            while (!isValidSet);

            SetPiece(Piece.Bishop, col);

            // Set Queen
            isValidSet = false;
            col = 0;
            do
            {
                col = rand.Next(0, 8);
                isValidSet = Row[col].piece == Piece.None;
            }
            while (!isValidSet);

            SetPiece(Piece.Queen, col);

            // Set Knights
            isValidSet = false;
            col = 0;

            for (int i = 0; i < 2; i++)
            {
                do
                {
                    col = rand.Next(0, 8);
                    isValidSet = Row[col].piece == Piece.None;
                }
                while (!isValidSet);

                SetPiece(Piece.Knight, col);
            }

            int piecesLeft = 0;

            rookIndex1 = 0;
            rookIndex2 = 0;
            kingIndex = 0;

            for (int index = 0; index < Row.Length; index++)
            {
                if (Row[index].piece == Piece.None)
                {
                    if (piecesLeft == 1)
                    {
                        kingIndex = index;
                        piecesLeft++;
                    }
                    else
                    {
                        if (piecesLeft == 0)
                        {
                            rookIndex1 = index;
                            piecesLeft++;
                        }
                        else
                            rookIndex2 = index;
                    }
                }
            }

            SetPiece(Piece.Rook, rookIndex1);
            SetPiece(Piece.Rook, rookIndex2);

            SetPiece(Piece.King, kingIndex);

            Assert.AreEqual(0, GetEmptyColumns());
        }
    }

    [TestClass]
    public class CheckHelperMethods
    {
        public int TryOffsetPositionWithinBounds(int position, int offset, int minInclusive = 0, int maxInclusive = 2)
        {
            if (position + offset <= maxInclusive && position + offset >= minInclusive)
                return position + offset;
            else
                return position;
        }

        private struct Position {
            public Position(int x, int y)
            {
                this.x = x; this.y = y;
            }
            public int x; public int y;
        }

        [TestMethod]
        public void CheckPositiveXOffsetWithinBound()
        {
            int[,] area = new int[3, 3];
            Position pos = new Position(1, 1);

            Assert.AreEqual(2,TryOffsetPositionWithinBounds(pos.x, 1));
        }

        [TestMethod]
        public void CheckNegativeXOffsetWithinBound()
        {
            int[,] area = new int[3, 3];
            Position pos = new Position(1, 1);

            Assert.AreEqual(0, TryOffsetPositionWithinBounds(pos.x, -1));
        }

        [TestMethod]
        public void CheckPositiveXOffsetWithoutBound()
        {
            //trying to move outside of the x-bound

            int[,] area = new int[3, 3];
            Position pos = new Position(1, 1);

            Assert.AreNotEqual(2, TryOffsetPositionWithinBounds(pos.x, 2));
        }

        [TestMethod]
        public void CheckNegativeXOffsetWithoutBound()
        {
            //trying to move outside of the x-bound

            int[,] area = new int[3, 3];
            Position pos = new Position(1, 1);

            Assert.AreNotEqual(0, TryOffsetPositionWithinBounds(pos.x, -2));
        }
    }

}
