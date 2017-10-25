using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormApps
{
    public static class PromptOptions
    {
        static int selectedOption;

        public static int ShowDialog(
            string formCaption = "", string labelText = "",
            string groupBoxText = "",
            int? formTop = null, int? formLeft = null,
            int formHeight = 0, int formWidth = 0,
            int formHeightMin = 0, int formWidthMin = 0,
            FormBorderStyle formBorderStyle =
            FormBorderStyle.Sizable,
            FormStartPosition formStartPosition =
            FormStartPosition.CenterParent,
            string[] options = null
            )
        {
            const int marginLeft = 20;
            const int marginRight = 30;
            const int marginTop = 10;
            const int marginBottom = 10;

            const int spacing = 20;


            if (formHeightMin == 0)
                formHeightMin = 140 + marginTop + marginBottom;
            if (formWidthMin == 0)
                formWidthMin = 200 + marginLeft + marginRight;


            var theForm = new Form();

            FormatForm(formCaption, formTop, formLeft, formHeight, formWidth,
                formHeightMin, formWidthMin, formBorderStyle,
                formStartPosition, theForm);

            Label textLabel =
                AddLabel(labelText, marginLeft, marginTop, theForm);

            GroupBox groupBox =
                AddGroupBox(groupBoxText, marginLeft, marginRight,
                marginTop, marginBottom, theForm, textLabel);

            Panel panel = AddPanel(groupBox);

            AddButtonOK(marginRight, marginBottom, theForm);

            AddButtonCancel(marginBottom, theForm);

            AddRadioButtons(options, spacing, panel);

            return theForm.ShowDialog() == DialogResult.OK ?
                selectedOption : -1;
            //btnOK.Click += (sender, e) => { prompt.Close(); };
        }

        static void FormatForm(string formCaption, int? formTop, int? formLeft,
            int formHeight, int formWidth, int formHeightMin, int formWidthMin,
            FormBorderStyle formBorderStyle,
            FormStartPosition formStartPosition, Form theForm)
        {
            if (formTop.HasValue) theForm.Top = (int)formTop;
            if (formLeft.HasValue) theForm.Left = (int)formLeft;
            theForm.Height = formHeight == 0 ? 200 : formHeight;
            theForm.Width = formWidth == 0 ? 320 : formWidth;

            theForm.MinimumSize = new Size(formWidthMin, formHeightMin);

            theForm.FormBorderStyle = formBorderStyle;
            theForm.StartPosition = formStartPosition;
            theForm.Text = formCaption;
        }

        static Label AddLabel(
            string labelText, int marginLeft, int marginTop, Form theForm)
        {
            var textLabel = new Label
            {
                Text = labelText,
                Top = marginTop,
                Left = marginLeft,
                Height = 20,
                Width = theForm.Width - 40,
                Anchor =
                    AnchorStyles.Left |
                    AnchorStyles.Right |
                    AnchorStyles.Top
            };
            theForm.Controls.Add(textLabel);
            return textLabel;
        }

        static GroupBox AddGroupBox(
            string groupBoxText, int marginLeft, int marginRight,
            int marginTop, int marginBottom, Form theForm, Label textLabel)
        {
            var groupBox = new GroupBox
            {
                Text = groupBoxText,
                Top = marginTop + textLabel.Height,
                Left = marginLeft,
                Height = theForm.Height - marginTop - marginBottom - 80,
                Width = theForm.Width - marginLeft - marginRight,
                Anchor =
                    AnchorStyles.Left |
                    AnchorStyles.Right |
                    AnchorStyles.Top |
                    AnchorStyles.Bottom,
                TabStop = true,
                TabIndex = 0
            };
            theForm.Controls.Add(groupBox);
            return groupBox;
        }

        static Panel AddPanel(GroupBox groupBox)
        {
            var panel = new Panel
            {
                AutoScroll = true,
                Anchor =
                    AnchorStyles.Left |
                    AnchorStyles.Right |
                    AnchorStyles.Top |
                    AnchorStyles.Bottom
            };
            groupBox.Controls.Add(panel);
            panel.Dock = DockStyle.Fill;
            return panel;
        }

        static void AddButtonOK(
            int marginRight, int marginBottom, Form theForm)
        {
            var btnOK = new Button
            {
                Text = "&OK",
                DialogResult = DialogResult.OK,
                Top = theForm.Height - marginBottom - 60,
                Left = theForm.Width - marginRight - 100,
                Width = 100,
                Anchor =
                    AnchorStyles.Right |
                    AnchorStyles.Bottom
            };
            theForm.Controls.Add(btnOK);
            theForm.AcceptButton = btnOK;
        }

        static void AddButtonCancel(int marginBottom, Form theForm)
        {
            var btnCancel = new Button
            {
                Text = "&Cancel",
                DialogResult = DialogResult.Cancel,
                Top = theForm.Height - marginBottom - 60,
                Left = 20,
                Width = 100,
                Anchor =
                    AnchorStyles.Left |
                    AnchorStyles.Bottom
            };
            theForm.Controls.Add(btnCancel);
            theForm.CancelButton = btnCancel;
        }

        static void AddRadioButtons(
            string[] options, int spacing, Panel panel)
        {
            int nrOptions = options.Length;
            RadioButton[] radioButtons = new RadioButton[nrOptions];

            for (int i = 0; i < nrOptions; i++)
            {
                radioButtons[i] = new RadioButton();
                //
                radioButtons[i].Tag = i;
                //
                radioButtons[i].Text = options[i];
                radioButtons[i].Top = (i) * spacing;
                radioButtons[i].Left = 5;
                radioButtons[i].Width = panel.Width - 10;
                radioButtons[i].Anchor = AnchorStyles.Top |
                    AnchorStyles.Left | AnchorStyles.Right;
                // Attach event handlers
                radioButtons[i].CheckedChanged += radioButtons_CheckedChanged;
                radioButtons[i].TabStop = true;

                panel.Controls.Add(radioButtons[i]);
            }
        }

        static void radioButtons_CheckedChanged(
            object sender, EventArgs e)
        {
            selectedOption = (int)(((RadioButton)sender).Tag);
        }
    }
}