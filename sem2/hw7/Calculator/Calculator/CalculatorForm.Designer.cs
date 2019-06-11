namespace Calculator
{
    partial class CalculatorForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.sevenButton = new System.Windows.Forms.Button();
            this.fourButton = new System.Windows.Forms.Button();
            this.oneButton = new System.Windows.Forms.Button();
            this.zeroButton = new System.Windows.Forms.Button();
            this.twoButton = new System.Windows.Forms.Button();
            this.threeButton = new System.Windows.Forms.Button();
            this.fiveButton = new System.Windows.Forms.Button();
            this.sixButton = new System.Windows.Forms.Button();
            this.eightButton = new System.Windows.Forms.Button();
            this.nineButton = new System.Windows.Forms.Button();
            this.divideButton = new System.Windows.Forms.Button();
            this.multiplyButton = new System.Windows.Forms.Button();
            this.subtractButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.equalButton = new System.Windows.Forms.Button();
            this.changeSignButton = new System.Windows.Forms.Button();
            this.decimalSeparatorButton = new System.Windows.Forms.Button();
            this.removeCurrentNumberButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.backspaceButton = new System.Windows.Forms.Button();
            this.currentNumberTextBox = new System.Windows.Forms.TextBox();
            this.expressionLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 4;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.Controls.Add(this.sevenButton, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.fourButton, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.oneButton, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.zeroButton, 1, 4);
            this.tableLayoutPanel.Controls.Add(this.twoButton, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.threeButton, 2, 3);
            this.tableLayoutPanel.Controls.Add(this.fiveButton, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.sixButton, 2, 2);
            this.tableLayoutPanel.Controls.Add(this.eightButton, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.nineButton, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.divideButton, 3, 0);
            this.tableLayoutPanel.Controls.Add(this.multiplyButton, 3, 1);
            this.tableLayoutPanel.Controls.Add(this.subtractButton, 3, 2);
            this.tableLayoutPanel.Controls.Add(this.addButton, 3, 3);
            this.tableLayoutPanel.Controls.Add(this.equalButton, 3, 4);
            this.tableLayoutPanel.Controls.Add(this.changeSignButton, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.decimalSeparatorButton, 2, 4);
            this.tableLayoutPanel.Controls.Add(this.removeCurrentNumberButton, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.clearButton, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.backspaceButton, 2, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 155);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 4;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(318, 346);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // sevenButton
            // 
            this.sevenButton.BackColor = System.Drawing.SystemColors.Menu;
            this.sevenButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sevenButton.Font = new System.Drawing.Font("Ebrima", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sevenButton.Location = new System.Drawing.Point(3, 69);
            this.sevenButton.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.sevenButton.Name = "sevenButton";
            this.sevenButton.Size = new System.Drawing.Size(76, 69);
            this.sevenButton.TabIndex = 0;
            this.sevenButton.Text = "7";
            this.sevenButton.UseVisualStyleBackColor = false;
            this.sevenButton.Click += new System.EventHandler(this.OnDigitButtonClick);
            // 
            // fourButton
            // 
            this.fourButton.BackColor = System.Drawing.SystemColors.Menu;
            this.fourButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fourButton.Font = new System.Drawing.Font("Ebrima", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fourButton.Location = new System.Drawing.Point(3, 138);
            this.fourButton.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.fourButton.Name = "fourButton";
            this.fourButton.Size = new System.Drawing.Size(76, 69);
            this.fourButton.TabIndex = 1;
            this.fourButton.Text = "4";
            this.fourButton.UseVisualStyleBackColor = false;
            this.fourButton.Click += new System.EventHandler(this.OnDigitButtonClick);
            // 
            // oneButton
            // 
            this.oneButton.BackColor = System.Drawing.SystemColors.Menu;
            this.oneButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.oneButton.Font = new System.Drawing.Font("Ebrima", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oneButton.Location = new System.Drawing.Point(3, 207);
            this.oneButton.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.oneButton.Name = "oneButton";
            this.oneButton.Size = new System.Drawing.Size(76, 69);
            this.oneButton.TabIndex = 2;
            this.oneButton.Text = "1";
            this.oneButton.UseVisualStyleBackColor = false;
            this.oneButton.Click += new System.EventHandler(this.OnDigitButtonClick);
            // 
            // zeroButton
            // 
            this.zeroButton.BackColor = System.Drawing.SystemColors.Menu;
            this.zeroButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zeroButton.Font = new System.Drawing.Font("Ebrima", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zeroButton.Location = new System.Drawing.Point(79, 276);
            this.zeroButton.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.zeroButton.Name = "zeroButton";
            this.zeroButton.Size = new System.Drawing.Size(79, 67);
            this.zeroButton.TabIndex = 3;
            this.zeroButton.Text = "0";
            this.zeroButton.UseVisualStyleBackColor = false;
            this.zeroButton.Click += new System.EventHandler(this.OnDigitButtonClick);
            // 
            // twoButton
            // 
            this.twoButton.BackColor = System.Drawing.SystemColors.Menu;
            this.twoButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.twoButton.Font = new System.Drawing.Font("Ebrima", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.twoButton.Location = new System.Drawing.Point(79, 207);
            this.twoButton.Margin = new System.Windows.Forms.Padding(0);
            this.twoButton.Name = "twoButton";
            this.twoButton.Size = new System.Drawing.Size(79, 69);
            this.twoButton.TabIndex = 4;
            this.twoButton.Text = "2";
            this.twoButton.UseVisualStyleBackColor = false;
            this.twoButton.Click += new System.EventHandler(this.OnDigitButtonClick);
            // 
            // threeButton
            // 
            this.threeButton.BackColor = System.Drawing.SystemColors.Menu;
            this.threeButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.threeButton.Font = new System.Drawing.Font("Ebrima", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.threeButton.Location = new System.Drawing.Point(158, 207);
            this.threeButton.Margin = new System.Windows.Forms.Padding(0);
            this.threeButton.Name = "threeButton";
            this.threeButton.Size = new System.Drawing.Size(79, 69);
            this.threeButton.TabIndex = 5;
            this.threeButton.Text = "3";
            this.threeButton.UseVisualStyleBackColor = false;
            this.threeButton.Click += new System.EventHandler(this.OnDigitButtonClick);
            // 
            // fiveButton
            // 
            this.fiveButton.BackColor = System.Drawing.SystemColors.Menu;
            this.fiveButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fiveButton.Font = new System.Drawing.Font("Ebrima", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fiveButton.Location = new System.Drawing.Point(79, 138);
            this.fiveButton.Margin = new System.Windows.Forms.Padding(0);
            this.fiveButton.Name = "fiveButton";
            this.fiveButton.Size = new System.Drawing.Size(79, 69);
            this.fiveButton.TabIndex = 6;
            this.fiveButton.Text = "5";
            this.fiveButton.UseVisualStyleBackColor = false;
            this.fiveButton.Click += new System.EventHandler(this.OnDigitButtonClick);
            // 
            // sixButton
            // 
            this.sixButton.BackColor = System.Drawing.SystemColors.Menu;
            this.sixButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sixButton.Font = new System.Drawing.Font("Ebrima", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sixButton.Location = new System.Drawing.Point(158, 138);
            this.sixButton.Margin = new System.Windows.Forms.Padding(0);
            this.sixButton.Name = "sixButton";
            this.sixButton.Size = new System.Drawing.Size(79, 69);
            this.sixButton.TabIndex = 7;
            this.sixButton.Text = "6";
            this.sixButton.UseVisualStyleBackColor = false;
            this.sixButton.Click += new System.EventHandler(this.OnDigitButtonClick);
            // 
            // eightButton
            // 
            this.eightButton.BackColor = System.Drawing.SystemColors.Menu;
            this.eightButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eightButton.Font = new System.Drawing.Font("Ebrima", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eightButton.Location = new System.Drawing.Point(79, 69);
            this.eightButton.Margin = new System.Windows.Forms.Padding(0);
            this.eightButton.Name = "eightButton";
            this.eightButton.Size = new System.Drawing.Size(79, 69);
            this.eightButton.TabIndex = 8;
            this.eightButton.Text = "8";
            this.eightButton.UseVisualStyleBackColor = false;
            this.eightButton.Click += new System.EventHandler(this.OnDigitButtonClick);
            // 
            // nineButton
            // 
            this.nineButton.BackColor = System.Drawing.SystemColors.Menu;
            this.nineButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nineButton.Font = new System.Drawing.Font("Ebrima", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nineButton.Location = new System.Drawing.Point(158, 69);
            this.nineButton.Margin = new System.Windows.Forms.Padding(0);
            this.nineButton.Name = "nineButton";
            this.nineButton.Size = new System.Drawing.Size(79, 69);
            this.nineButton.TabIndex = 9;
            this.nineButton.Text = "9";
            this.nineButton.UseVisualStyleBackColor = false;
            this.nineButton.Click += new System.EventHandler(this.OnDigitButtonClick);
            // 
            // divideButton
            // 
            this.divideButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.divideButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.divideButton.Font = new System.Drawing.Font("Ebrima", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.divideButton.Location = new System.Drawing.Point(237, 0);
            this.divideButton.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.divideButton.Name = "divideButton";
            this.divideButton.Size = new System.Drawing.Size(78, 69);
            this.divideButton.TabIndex = 10;
            this.divideButton.Text = "÷";
            this.divideButton.UseVisualStyleBackColor = false;
            this.divideButton.Click += new System.EventHandler(this.OnOperationButtonClick);
            // 
            // multiplyButton
            // 
            this.multiplyButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.multiplyButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiplyButton.Location = new System.Drawing.Point(237, 69);
            this.multiplyButton.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.multiplyButton.Name = "multiplyButton";
            this.multiplyButton.Size = new System.Drawing.Size(78, 69);
            this.multiplyButton.TabIndex = 11;
            this.multiplyButton.Text = "×";
            this.multiplyButton.UseVisualStyleBackColor = false;
            this.multiplyButton.Click += new System.EventHandler(this.OnOperationButtonClick);
            // 
            // subtractButton
            // 
            this.subtractButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.subtractButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subtractButton.Location = new System.Drawing.Point(237, 138);
            this.subtractButton.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.subtractButton.Name = "subtractButton";
            this.subtractButton.Size = new System.Drawing.Size(78, 69);
            this.subtractButton.TabIndex = 12;
            this.subtractButton.Text = "-";
            this.subtractButton.UseVisualStyleBackColor = false;
            this.subtractButton.Click += new System.EventHandler(this.OnOperationButtonClick);
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.addButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addButton.Location = new System.Drawing.Point(237, 207);
            this.addButton.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(78, 69);
            this.addButton.TabIndex = 13;
            this.addButton.Text = "+";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.OnOperationButtonClick);
            // 
            // equalButton
            // 
            this.equalButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.equalButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.equalButton.Location = new System.Drawing.Point(237, 276);
            this.equalButton.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.equalButton.Name = "equalButton";
            this.equalButton.Size = new System.Drawing.Size(78, 67);
            this.equalButton.TabIndex = 14;
            this.equalButton.Text = "=";
            this.equalButton.UseVisualStyleBackColor = false;
            this.equalButton.Click += new System.EventHandler(this.OnEqualButtonClick);
            // 
            // changeSignButton
            // 
            this.changeSignButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.changeSignButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.changeSignButton.Location = new System.Drawing.Point(3, 276);
            this.changeSignButton.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.changeSignButton.Name = "changeSignButton";
            this.changeSignButton.Size = new System.Drawing.Size(76, 67);
            this.changeSignButton.TabIndex = 15;
            this.changeSignButton.Text = "±";
            this.changeSignButton.UseVisualStyleBackColor = false;
            this.changeSignButton.Click += new System.EventHandler(this.OnChangeSignButtonClick);
            // 
            // decimalSeparatorButton
            // 
            this.decimalSeparatorButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.decimalSeparatorButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.decimalSeparatorButton.Location = new System.Drawing.Point(158, 276);
            this.decimalSeparatorButton.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.decimalSeparatorButton.Name = "decimalSeparatorButton";
            this.decimalSeparatorButton.Size = new System.Drawing.Size(79, 67);
            this.decimalSeparatorButton.TabIndex = 16;
            this.decimalSeparatorButton.Text = ",";
            this.decimalSeparatorButton.UseVisualStyleBackColor = false;
            this.decimalSeparatorButton.Click += new System.EventHandler(this.OnDecimalSeparatorButtonClick);
            // 
            // removeCurrentNumberButton
            // 
            this.removeCurrentNumberButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.removeCurrentNumberButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.removeCurrentNumberButton.Location = new System.Drawing.Point(3, 0);
            this.removeCurrentNumberButton.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.removeCurrentNumberButton.Name = "removeCurrentNumberButton";
            this.removeCurrentNumberButton.Size = new System.Drawing.Size(76, 69);
            this.removeCurrentNumberButton.TabIndex = 17;
            this.removeCurrentNumberButton.Text = "CE";
            this.removeCurrentNumberButton.UseVisualStyleBackColor = false;
            this.removeCurrentNumberButton.Click += new System.EventHandler(this.OnRemoveCurrentNumberButtonClick);
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.clearButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clearButton.Location = new System.Drawing.Point(79, 0);
            this.clearButton.Margin = new System.Windows.Forms.Padding(0);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(79, 69);
            this.clearButton.TabIndex = 18;
            this.clearButton.Text = "C";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.OnClearButtonClick);
            // 
            // backspaceButton
            // 
            this.backspaceButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.backspaceButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backspaceButton.Location = new System.Drawing.Point(158, 0);
            this.backspaceButton.Margin = new System.Windows.Forms.Padding(0);
            this.backspaceButton.Name = "backspaceButton";
            this.backspaceButton.Size = new System.Drawing.Size(79, 69);
            this.backspaceButton.TabIndex = 19;
            this.backspaceButton.Text = "←";
            this.backspaceButton.UseVisualStyleBackColor = false;
            this.backspaceButton.Click += new System.EventHandler(this.OnBackspaceButtonClick);
            // 
            // currentNumberTextBox
            // 
            this.currentNumberTextBox.Font = new System.Drawing.Font("Ebrima", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentNumberTextBox.Location = new System.Drawing.Point(3, 94);
            this.currentNumberTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.currentNumberTextBox.Name = "currentNumberTextBox";
            this.currentNumberTextBox.Size = new System.Drawing.Size(321, 73);
            this.currentNumberTextBox.TabIndex = 1;
            this.currentNumberTextBox.Text = "0";
            this.currentNumberTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.currentNumberTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CurrentNumberTextBoxTextChanged);
            // 
            // expressionLabel
            // 
            this.expressionLabel.Font = new System.Drawing.Font("Ebrima", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expressionLabel.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.expressionLabel.Location = new System.Drawing.Point(4, 27);
            this.expressionLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.expressionLabel.Name = "expressionLabel";
            this.expressionLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.expressionLabel.Size = new System.Drawing.Size(314, 58);
            this.expressionLabel.TabIndex = 2;
            this.expressionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CalculatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(20F, 48F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(318, 501);
            this.Controls.Add(this.expressionLabel);
            this.Controls.Add(this.currentNumberTextBox);
            this.Controls.Add(this.tableLayoutPanel);
            this.Font = new System.Drawing.Font("Ebrima", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.Name = "CalculatorForm";
            this.Text = "Calculator";
            this.Load += new System.EventHandler(this.CalculatorLoad);
            this.tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button sevenButton;
        private System.Windows.Forms.Button fourButton;
        private System.Windows.Forms.Button fiveButton;
        private System.Windows.Forms.Button sixButton;
        private System.Windows.Forms.Button eightButton;
        private System.Windows.Forms.Button nineButton;
        private System.Windows.Forms.Button divideButton;
        private System.Windows.Forms.Button multiplyButton;
        private System.Windows.Forms.Button subtractButton;
        private System.Windows.Forms.Button removeCurrentNumberButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button backspaceButton;
        private System.Windows.Forms.Button oneButton;
        private System.Windows.Forms.Button twoButton;
        private System.Windows.Forms.Button threeButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button zeroButton;
        private System.Windows.Forms.Button equalButton;
        private System.Windows.Forms.Button changeSignButton;
        private System.Windows.Forms.Button decimalSeparatorButton;
        private System.Windows.Forms.TextBox currentNumberTextBox;
        private System.Windows.Forms.Label expressionLabel;
    }
}

