﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DifficultyForm
{
    // The main GridForm class
    public partial class GridForm : Form
    {
        // Private fields for storing the size of the grid and the grid buttons.
        private int gridLength;
        private Button[,] buttons;

        // Constructor for the GridForm, taking a gridLength parameter.
        public GridForm(int gridSize)
        {
            // Store the gridSize parameter in the gridLength field.
            gridLength = gridSize;

            // Call InitializeComponent, a method generated by the Windows Forms designer.
            InitializeComponent();
        }

        // Method to create the grid of buttons.
        private void CreateGrid()
        {
            // Initialize the buttons array with the specified grid size.
            buttons = new Button[gridLength, gridLength];

            // Constants for the size of each button and the size of the grid.
            int buttonSize = 30;
            int gridWidth = gridLength * buttonSize;
            int gridHeight = gridLength * buttonSize;

            // Nested loops to create each button in the grid.
            for (int i = 0; i < gridLength; i++)
            {
                for (int j = 0; j < gridLength; j++)
                {
                    // Create a new button, set its size and location, and add an event handler for its Click event.
                    Button btn = new Button();
                    btn.Size = new Size(buttonSize, buttonSize);
                    btn.Location = new Point(i * buttonSize, j * buttonSize);
                    btn.Click += GridButton_Click;

                    // Store the button in the _buttons array and add it to the form's Controls collection.
                    buttons[i, j] = btn;
                    this.Controls.Add(btn);
                }
            }

            // Adjust the size of the form to fit the grid.
            this.ClientSize = new Size(gridWidth, gridHeight);
        }

        // Event handler for the Click event of each button in the grid.
        private void GridButton_Click(object sender, EventArgs e)
        {
            // Cast the sender to a Button (since this event handler is for Button objects).
            Button clickedButton = sender as Button;

            // Change the background color of the clicked button to red.
            clickedButton.BackColor = Color.Red;
        }

        // Event handler for the Load event of the form.
        private void GridForm_Load(object sender, EventArgs e)
        {
            // Call CreateGrid to create the grid when the form loads.
            CreateGrid();
        }
    }
}