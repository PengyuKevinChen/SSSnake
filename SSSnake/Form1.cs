using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging; // for jpg compressor
using System.Windows.Forms;

// Credit: Moo ICT @ https://www.youtube.com/watch?v=TzaCn1ZPalI&t=3415s

namespace SSSnake
{
    public partial class Form1 : Form
    {
        private List<Circle> _snake = new();
        private Circle _food = new();

        private int _maxWidth;
        private int _maxHeight;

        private int _score;
        private int _highScore;

        private readonly Random _rand = new();

        private bool _goLeft, _goRight, _goDown, _goUp;

        public Form1()
        {
            InitializeComponent();

            new Settings();
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && Settings.directions != "right")
            {
                _goLeft = true;
            }

            if (e.KeyCode == Keys.Right && Settings.directions != "left")
            {
                _goRight = true;
            }

            if (e.KeyCode == Keys.Up && Settings.directions != "down")
            {
                _goUp = true;
            }

            if (e.KeyCode == Keys.Down && Settings.directions != "up")
            {
                _goDown = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                _goLeft = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                _goRight = false;
            }

            if (e.KeyCode == Keys.Up)
            {
                _goUp = false;
            }

            if (e.KeyCode == Keys.Down)
            {
                _goDown = false;
            }
        }

        private void StartGame(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void TakeSnapShot(object sender, EventArgs e)
        {
            var caption = new Label
            {
                Text = "I scored: " + _score + " and my Highscore is " + _highScore + " on the Snake Game",
                Font = new Font("Ariel", 12, FontStyle.Bold),
                ForeColor = Color.Navy,
                AutoSize = false,
                Width = picCanvas.Width,
                Height = 30,
                TextAlign = ContentAlignment.MiddleCenter
            };
            picCanvas.Controls.Add(caption);

            var dialog = new SaveFileDialog
            {
                FileName = "Snake Game SnapShot", DefaultExt = "jpg", Filter = "JPG Image File | *.jpg",
                ValidateNames = true
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var width = Convert.ToInt32(picCanvas.Width);
                var height = Convert.ToInt32(picCanvas.Height);
                var bmp = new Bitmap(width, height);
                picCanvas.DrawToBitmap(bmp, new Rectangle(0, 0, width, height));
                bmp.Save(dialog.FileName, ImageFormat.Jpeg);
                picCanvas.Controls.Remove(caption);
            }
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            // setting the directions

            if (_goLeft)
            {
                Settings.directions = "left";
            }

            if (_goRight)
            {
                Settings.directions = "right";
            }

            if (_goDown)
            {
                Settings.directions = "down";
            }

            if (_goUp)
            {
                Settings.directions = "up";
            }
            // end of directions

            for (var i = _snake.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (Settings.directions)
                    {
                        case "left":
                            _snake[i].X--;
                            break;
                        case "right":
                            _snake[i].X++;
                            break;
                        case "down":
                            _snake[i].Y++;
                            break;
                        case "up":
                            _snake[i].Y--;
                            break;
                    }

                    if (_snake[i].X < 0)
                    {
                        _snake[i].X = _maxWidth;
                    }

                    if (_snake[i].X > _maxHeight)
                    {
                        _snake[i].X = 0;
                    }

                    if (_snake[i].Y < 0)
                    {
                        _snake[i].Y = _maxHeight;
                    }

                    if (_snake[i].Y > _maxHeight)
                    {
                        _snake[i].Y = 0;
                    }

                    if (_snake[i].X == _food.X && _snake[i].Y == _food.Y)
                    {
                        EatFood();
                    }

                    for (var j = 1; j < _snake.Count; j++)
                    {
                        if (_snake[i].X == _snake[j].X && _snake[i].Y == _snake[j].Y)
                        {
                            GameOver();
                        }
                    }
                }
                else
                {
                    _snake[i].X = _snake[i - 1].X;
                    _snake[i].Y = _snake[i - 1].Y;
                }
            }

            picCanvas.Invalidate();
        }

        private void UpdatePictureBoxGraphics(object sender, PaintEventArgs e)
        {
            var canvas = e.Graphics;

            for (var i = 0; i < _snake.Count; i++)
            {
                Brush snakeColour;
                if (i == 0)
                {
                    snakeColour = Brushes.Azure;
                }
                else
                {
                    snakeColour = Brushes.Gold;
                }

                canvas.FillEllipse(snakeColour, new Rectangle(
                    _snake[i].X * Settings.Width,
                    _snake[i].Y * Settings.Height,
                    Settings.Width,
                    Settings.Height
                ));
            }

            canvas.FillEllipse(Brushes.Gold, new Rectangle(
                _food.X * Settings.Width,
                _food.Y * Settings.Height,
                Settings.Width,
                Settings.Height
            ));
        }

        private void RestartGame()
        {
            _maxWidth = picCanvas.Width / Settings.Width - 1;
            _maxHeight = picCanvas.Height / Settings.Height - 1;

            _snake.Clear();

            startButton.Enabled = false;
            snapButton.Enabled = false;
            _score = 0;
            txtScore.Text = "Score: " + _score;

            var head = new Circle {X = 10, Y = 5};
            _snake.Add(head); // adding the head part of the snake to the list

            for (var i = 0; i < 10; i++)
            {
                var body = new Circle();
                _snake.Add(body);
            }

            _food = new Circle {X = _rand.Next(2, _maxWidth), Y = _rand.Next(2, _maxHeight)};
            gameTimer.Start();
        }

        private void EatFood()
        {
            _score += 1;
            txtScore.Text = "Score: " + _score;

            var body = new Circle
            {
                X = _snake[_snake.Count - 1].X,
                Y = _snake[_snake.Count - 1].Y
            };
            _snake.Add(body);

            _food = new Circle {X = _rand.Next(2, _maxWidth), Y = _rand.Next(2, _maxHeight)};
        }

        private void GameOver()
        {
            gameTimer.Stop();
            startButton.Enabled = true;
            snapButton.Enabled = true;

            if (_score > _highScore)
            {
                _highScore = _score;

                txtHighScore.Text = "High Score: " + Environment.NewLine + _highScore;
                txtHighScore.ForeColor = Color.Maroon;
                txtHighScore.TextAlign = ContentAlignment.MiddleCenter;
            }
        }
    }
}