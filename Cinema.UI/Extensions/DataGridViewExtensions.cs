using Cinema.Domain;
using Cinema.Domain.CustomFlags;
using Cinema.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema.UI.Extensions
{
    internal static class DataGridViewExtensions
    {
        static Func<DataGridView, object> defaultBindingAction = x => 
        {
            for (int i = 0; i < x.Columns.Count - 1; i++)
            {
                x.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            return x;
        };

        /// <summary>
        /// Configura el comportamiento requerido para ajustar las columnas al tamaño del grid, al igual que el evento Click.
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="cellClickEvent"></param>
        public static void SetupBehaviour(this DataGridView grid, DataGridViewCellEventHandler cellClickEvent = null, Func<DataGridView, object> bindingAction = null)
        {
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.DataBindingComplete += BindingComplete;
            grid.RowHeadersVisible = false;
            grid.ReadOnly = true;

            grid.Tag = new List<Func<DataGridView, object>>();
            var gridcontainer = grid.Tag as List<Func<DataGridView, object>>;
            gridcontainer.Add(defaultBindingAction);

            if(bindingAction != null)
                gridcontainer.Add(bindingAction);
                
            if (cellClickEvent != null)
                grid.CellClick += cellClickEvent;
        }

        private static void BindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                var grid = sender as DataGridView;
                var gridcontainer = grid.Tag as List<Func<DataGridView, object>>;

                if(gridcontainer != null)
                {
                    if (gridcontainer.Count == 0)
                        return;
                    else if (gridcontainer.Count == 1)
                        gridcontainer[0].Invoke(grid);
                    else if (gridcontainer.Count == 2 && gridcontainer[1] != null)
                        gridcontainer[1].Invoke(grid);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private static TOut GetTuple<TOut>(params object[] values)
        {
            Type specificType = typeof(TOut);

            Type genericType = Type.GetType("System.Tuple`" + values.Length);
            Type[] typeArgs = values.Select(item => item.GetType()).ToArray();
            object[] constructorArguments = values.Cast<object>().ToArray();
            return (TOut)Activator.CreateInstance(specificType, constructorArguments);
        }

        private static TOut GetObject<TOut>()
        {
            Type specificType = typeof(TOut);
            return (TOut)Activator.CreateInstance(specificType);
        }

        public static DataGridViewCell? GetCellAt(this DataGridView sender, int row, int column)
        {
            try
            {
                return sender.Rows[row].Cells[column];
            }
            catch (Exception)
            {
                return null;
            }

        }


        /// <summary>
        /// Permite obtener el valor de las celdas del grid. Obtiene la cantidad de celdas segun
        /// la cantidad de tipos especificados como parametro de Tupla. Si se especifica un tipo unico,
        /// devuelve ese tipo unico.
        /// Permite especificar la columna. La cantidad de columnas y de tipos debe coincidir.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sender"></param>
        /// <param name="indexes"></param>
        /// <returns>Un objeto complejo de tipo Tupla'N creado a partir del tipo dado.</returns>
        public static T GetCellValues<T>(this DataGridView sender, params object[] indexes)
        {
            Type type = typeof(T);

            var fields = type.GetFields();

            var props = type.GetProperties();

            var row = sender.SelectedRows[0];

            List<object> values = new List<object>();

            int i = 0;

            if (fields.Length > 0)
            {
                if (indexes.Length > 0 && indexes.Length != fields.Length)
                    throw new Exception("La cantidad de tipos y de indices no pueden ser diferentes.");

                if (indexes.Length > 0)
                {
                    foreach (int index in indexes)
                    {
                        if (fields[i].FieldType == typeof(Guid) || fields[i].FieldType == typeof(Guid?))
                            values.Add(Guid.Parse(row.Cells[index - 1].Value?.ToString()));
                        else
                            values.Add(Convert.ChangeType(row.Cells[index - 1].Value?.ToString(), fields[i].FieldType));
                        i++;
                    }
                }
                else
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (i >= fields.Length)
                            break;
                        if (fields[i].FieldType == typeof(Guid) || fields[i].FieldType == typeof(Guid?))
                            values.Add(Guid.Parse(cell.Value.ToString()));
                        else
                            values.Add(Convert.ChangeType(cell.Value?.ToString(), fields[i].FieldType));

                        i++;
                    }
                }

                if (fields.Length == 1)
                {
                    return (T)values[0];
                }
                else
                {
                    return GetTuple<T>(values.ToArray());
                }
            }
            else
            {
                if (indexes.Length > 0 && indexes.Length != props.Length)
                    throw new Exception("La cantidad de propiedades y de indices no pueden ser diferentes.");

                var result = GetObject<T>();

                if (indexes.Length > 0)
                {
                    foreach (int index in indexes)
                    {
                        if (props[i].PropertyType == typeof(Guid) || props[i].PropertyType == typeof(Guid?))
                        {
                            var value = Guid.Parse(row.Cells[index - 1].Value?.ToString());
                            props[i].SetValue(result, value);
                        }
                        else
                        {
                            var value = Convert.ChangeType(row.Cells[index - 1].Value?.ToString(), props[i].PropertyType);
                            props[i].SetValue(result, value);
                        }
                        i++;
                    }
                }
                else
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (i >= props.Length)
                            break;

                        if (props[i].PropertyType == typeof(Guid) || props[i].PropertyType == typeof(Guid?))
                        {
                            var value = Guid.Parse(cell.Value.ToString());
                            props[i].SetValue(result, value);
                        }
                        else
                        {
                            var value = Convert.ChangeType(cell.Value?.ToString(), props[i].PropertyType);
                            props[i].SetValue(result, value);
                        }
                        i++;
                    }
                }

                return result;
            }
        }

        private static void AddRow(List<string> row, object obj, PropertyInfo prop)
        {
            if (obj == null)
            {
                row.Add("");
                return;
            }

            var value = prop.GetValue(obj);

            if (value == null)
            {
                row.Add("");
                return;
            }

            row.Add(value.ToString());
        }

        public static List<PropertyInfo> GetVisibleProperties<T>(T obj = null) where T : class
        {
            Type type;

            if (obj == null)
                type = typeof(T);
            else
                type = obj.GetType();

            var props = new List<PropertyInfo>();

            type.GetProperties().ToList().ForEach(x =>
            {
                var flag = x.GetFlag<VisibleOnGrid>();

                if (flag == null)
                    return;

                props.Add(x);
            });

            return props;
        }

        /// <summary>
        /// Agrega un objeto al grid utilizando los nombres de sus propiedades.
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="obj"></param>
        public static void Add(this DataGridView grid, object obj)
        {
            Type type = obj.GetType();

            List<PropertyInfo> props = GetVisibleProperties(obj);

            if (grid.Tag == null)
            {
                grid.Tag = type;

                DataTable dt = new DataTable();

                foreach (var prop in props)
                {
                    var flag = prop.GetFlag<VisibleOnGrid>();

                    //var header = flag != null && flag.Name != "" ? flag.Name : prop.Name;

                    dt.Columns.Add(flag.Name);
                }

                var row = new List<string>();

                foreach (var prop in props)
                {
                    AddRow(row, obj, prop);
                }

                dt.Rows.Add(row.ToArray());

                grid.DataSource = null;
                grid.DataSource = dt;
            }
            else
            {
                var row = new List<string>();

                foreach (var prop in props)
                {
                    var value = prop.GetValue(obj);
                    if (value == null)
                    {
                        row.Add("");
                        continue;
                    }

                    AddRow(row, obj, prop);
                }

                (grid.DataSource as DataTable).Rows.Add(row.ToArray());
            }
        }


        /// <summary>
        /// Borra los datos del grid. DataSource y Tag se vuelven nulos.
        /// </summary>
        /// <param name="grid"></param>
        public static void Clear(this DataGridView grid)
        {
            grid.DataSource = null;
            grid.Tag = null;
        }

        /// <summary>
        /// Actualiza los nombres de las columnas de un grid. Hecho especialmente para se utilizado con un traductor. 
        /// Este metodo busca codigos de traduccion en flags "Description" en el objeto mapeado al grid a partir
        /// de su propiedad Tag. Si Tag es null, no hace nada.
        /// Si la funcion no filtra el procesamiento de la actualizacion, deja el nombre del codigo de traduccion en su lugar.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="grid"></param>
        /// <param name="func"></param>
        public static void UpdateNames<T>(this DataGridView grid, Func<string, string> func = null) where T : class
        {
            if (grid.Tag != null)
            {
                var type = typeof(T);

                var props = GetVisibleProperties<T>();

                var columns = (grid.DataSource as DataTable).Columns;
                int i = 0;
                foreach (DataColumn column in columns)
                {
                    var flag = props[i].GetFlag<VisibleOnGrid>();
                    if (func == null)
                    {
                        if (flag == null || flag.Name == "")
                            column.ColumnName = GetDescription<T>(props[i].Name);
                        else
                            column.ColumnName = flag.Name;
                    }
                    else
                    {
                        if (flag == null || flag.Name == "")
                            column.ColumnName = func?.Invoke(GetDescription<T>(props[i].Name));
                        else
                            column.ColumnName = func?.Invoke(flag.Name);
                    }
                    i++;
                }
            }
        }

        private static String GetDescription<T>(string name)
        {
            String valueText = name;

            Type type = typeof(T);

            PropertyInfo pi = type.GetProperty(valueText);

            Object[] attributes = pi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
            {
                DescriptionAttribute attribute = (DescriptionAttribute)attributes[0];
                return attribute.Description;
            }

            return valueText;
        }
    }
}
