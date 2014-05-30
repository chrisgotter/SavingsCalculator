using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NameSort : System.Web.UI.Page
{
  private int inputCount = 1;
  const int inputsDesired = 10;
  List<Control[]> input_array = new List<Control[]>(inputsDesired);

  protected void Page_Load(object sender, EventArgs e)
  {
    addBoxes(inputsDesired);
  }

  private void addBoxes(int argB)
  {
    while (inputCount <= argB)
    {

      Control[] control_array = 
        {
          new Label(),
          new TextBox(),
          new Label()
        };

      ((Label)control_array[0]).Text = "Name " + inputCount;
      control_array[0].ID = "lbl_name" + inputCount;
      control_array[1].ID = "txt_name" + inputCount;
      control_array[2].ID = "lbl_err" + inputCount;

      control_array[2].Visible = false;

      input_array.Add(control_array);

      TableRow row = new TableRow();

      foreach (Control control in control_array)
      {
        TableCell cell = new TableCell();
        cell.Controls.Add(control);
        row.Cells.Add(cell);
      }
      tbl_input.Rows.Add(row);
      inputCount++;
    }

  }

  protected void btn_submit_Click(object sender, EventArgs e)
  {
    List<string> names = new List<string>();
    foreach (Control[] control in input_array)
    {
      names.Add(((TextBox)control[1]).Text);


    }
    names.Sort();
    largestToCaps(names);


    displayNames(names);
  }

  private void displayNames(List<string> names)
  {

    lbl_list.Text = "<br />" + "Sorted Names with longest capitalized";
    foreach (string name in names)
    {
      lbl_list.Text += (name != "" ? "<br />" : "") + name;
    }

  }

  private static void largestToCaps(List<string> names)
  {
    List<int> largest = new List<int>(10);
    largest.Add(0);
    for (int i = 1; i < inputsDesired; i++)
    {
      if (names[i].Length > names[largest[0]].Length)
      {
        largest.Clear();
        largest.Add(i);
      }
      else if (names[i].Length == names[largest[0]].Length)
      {
        largest.Add(i);
      }
    }

    foreach (int i in largest)
    {
      names[i] = names[i].ToUpper();
    }
  }
}