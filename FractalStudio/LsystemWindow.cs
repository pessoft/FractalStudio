﻿using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace FractalStudio
{
    public partial class LsystemWindow : Form, IWindowModal
    {
        CreateLsystemEventArgs _LsysArg;
        EventHandler<CreateLsystemEventArgs> _Create;
        IGroupCreate _groupCrt;
        Dictionary<char, string> _rules;
        int selectIndex = -1;
        public LsystemWindow(EventHandler<CreateLsystemEventArgs> create)
        {
            InitializeComponent();
            _rules = new Dictionary<char, string>();
            _Create = create;
        }

        private void btnCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOkClick(object sender, EventArgs e)
        {
            _groupCrt.ContainerGroup.Controls.Clear();
            _groupCrt.ContainerGroup.Text = this.Text;
            panelLsystem.Controls.Remove(btnCancel);
            btnOk.Left = btnCancel.Left;
            
            _groupCrt.ContainerGroup.Controls.Add(panelLsystem);

            _LsysArg = new CreateLsystemEventArgs();
            _LsysArg.Angle = Convert.ToInt32(numericUpDownAngle.Value);
            _LsysArg.InitAngle = Convert.ToInt32(numericUpDownInitAngle.Value);
            _LsysArg.Axioma = txtAxiom.Text;
            _LsysArg.Rules = _rules;
            _LsysArg.Iteration = Convert.ToInt32(numericUpDownIteration.Value);
            _Create(this, _LsysArg);
            this.Close();
        }


        public DialogResult ShowDialog(IGroupCreate owner)
        {
            _groupCrt = owner;
            return this.ShowDialog();
        }

        private void comboBoxRules_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && comboBoxRules.Text.IndexOf(("->")) != -1)
            {
                #region Переделать комбобокс, башка не рубит
                //throw new NotImplementedException();
                //string value = comboBoxRules.Text.Trim();
                //if (value == "")
                //{
                //    if (comboBoxRules.Items.Count > comboBoxRules.SelectedIndex && comboBoxRules.SelectedIndex >= 0)
                //        comboBoxRules.Items.RemoveAt(comboBoxRules.SelectedIndex);
                //}
                //else
                //{
                //    if (comboBoxRules.Items.Count > comboBoxRules.SelectedIndex && comboBoxRules.SelectedIndex >= 0)
                //        comboBoxRules.Items[comboBoxRules.SelectedIndex] = value;
                //    else
                //        comboBoxRules.Items.Add(value);
                //}

                //MessageBox.Show(comboBoxRules.SelectedIndex.ToString());
                #endregion
                if (!comboBoxRules.Items.Contains(comboBoxRules.Text))
                {
                    char key = comboBoxRules.Text.Substring(0, comboBoxRules.Text.IndexOf("->")).ToCharArray()[0];
                    string value = comboBoxRules.Text.Substring(comboBoxRules.Text.IndexOf("->") + 2, comboBoxRules.Text.Length - 3);
                    if (_rules.ContainsKey(key))
                        _rules[key] = value;
                    else
                        _rules.Add(key, value);
                }
                comboBoxRules.Text = "";
            }
        }

        private void ComboBoxRulesSelectedIndexChanged(object sender, EventArgs e)
        {
            selectIndex = comboBoxRules.SelectedIndex;
        }
    }
}
