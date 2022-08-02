using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseServices.Domain;
using BaseServices.Services;
using Cinema.UI.Extensions;
using Cinema.UI.Services;

namespace Cinema.UI.AdminViews
{
    public partial class RolesPanel : UserControl
    {
        RolePermissionManagementService _rolePermissionManagementService;
        ExceptionHandler _exhandler;
        ControlTranslationService _controlTranslationService;
        LanguageService _languageService;
        Rol selectedRol;
        Permiso selectedPermiso;
        Permiso selectedPermisoRelation;
        Permiso comboSelectedPermiso;

        /// <summary>
        /// Constructor por defecto con servicios necesarios para operar. Hecho para contenedor de inyeccion de dependencia.
        /// </summary>
        /// <param name="rolePermissionManagementService"></param>
        /// <param name="controlTranslationService"></param>
        /// <param name="languageService"></param>
        /// <param name="exhandler"></param>
        public RolesPanel(RolePermissionManagementService rolePermissionManagementService,
            ControlTranslationService controlTranslationService,
            LanguageService languageService,
            ExceptionHandler exhandler)
        {
            InitializeComponent();
            this.Name = "text_roles";

            _rolePermissionManagementService = rolePermissionManagementService;
            _controlTranslationService = controlTranslationService;   
            _languageService = languageService;
            _exhandler = exhandler;

            controlTranslationService.OnRefresh += () =>
            {
                controlTranslationService.TryTranslateForm(this);
                GridPermisos.UpdateNames<Permiso>(x => _languageService.TranslateCode(x));
                GridRelaciones.UpdateNames<Permiso>(x => _languageService.TranslateCode(x));
            };

            GridRoles.SetupBehaviour(OnGridRoleClick);
            GridPermisos.SetupBehaviour(OnGridPermisoClick);
            GridRelaciones.SetupBehaviour(OnGridRelationClick);
        }

        private void OnGridRelationClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var permiso = GridRelaciones.GetCellValues<Permiso>();
                selectedPermisoRelation = permiso;
            }
            catch (Exception ex)
            {

            }
        }

        private void OnGridPermisoClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                (int Id, string Permiso, string Codigo) = GridPermisos.GetCellValues<(int, string, string)>();
                selectedPermiso = new Permiso(Id, Codigo);
                TxtCodigoPermiso.Text = selectedPermiso.Codigo;
                TxtIdPermiso.Text = selectedPermiso.Id.ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private void UpdateRelations()
        {
            try
            {
                GridRelaciones.Clear();
                _rolePermissionManagementService.ObtenerListaDePermisos(selectedRol).ForEach(x => GridRelaciones.Add(x));
            }
            catch (Exception ex)
            {

            }
        }

        private void OnGridRoleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedRol = GridRoles.GetCellValues<Rol>();
                GridRelaciones.Clear();
                TxtIdRol.Text = selectedRol.Id.ToString();
                TxtNombreRol.Text = selectedRol.Nombre;
                UpdateRelations();
            }
            catch (Exception ex)
            {

            }
        }

        private void BtnBuscarRoles_Click(object sender, EventArgs e)
        {
            try
            {
                GridRoles.Clear();
                _rolePermissionManagementService.ObtenerListaDeRoles().ForEach(x => GridRoles.Add(new { x.Id, x.Nombre }, false));
            }
            catch (Exception ex)
            {

            }
        }

        private void BtnCrearRol_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtNombreRol.Text.Length > 9)
                {
                    _rolePermissionManagementService.CrearRol(new Rol() { Nombre = TxtNombreRol.Text });
                    BtnBuscarRoles.PerformClick();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void BtnModificarRol_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(TxtIdRol.Text, out int id) && TxtNombreRol.Text.Length > 9)
                {
                    _rolePermissionManagementService.ModificarRol(new Rol() { Id = id, Nombre = TxtNombreRol.Text });
                    BtnBuscarRoles.PerformClick();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void BtnEliminarRol_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedRol != null)
                {
                    _rolePermissionManagementService.EliminarRol(selectedRol.Id);
                    BtnBuscarRoles.PerformClick();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void ComboPermisos_DropDown(object sender, EventArgs e)
        {
            try
            {
                ComboPermisos.Items.Clear();
                ComboPermisos.Items.AddRange(_rolePermissionManagementService.ObtenerListaDePermisos().Distinct().ToArray());
            }
            catch (Exception ex)
            {

            }
        }

        private void ComboPermisos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboSelectedPermiso = (sender as ComboBox).GetSelectedObject<Permiso>();
            }
            catch (Exception ex)
            {

            }
        }

        private void BtnEliminarRelacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedPermisoRelation != null)
                    _rolePermissionManagementService.EliminarRolPermisoRelation(new RolPermisoRelation() { IdRol = selectedRol.Id, IdPermiso = selectedPermisoRelation.Id });
                UpdateRelations();
            }
            catch (Exception ex)
            {

            }
        }

        private void BtnAgregarRelacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedRol != null && selectedRol.Id != 0 && comboSelectedPermiso != null && comboSelectedPermiso.Id != 0)
                    _rolePermissionManagementService.CrearRolPermisoRelation(new RolPermisoRelation() { IdRol = selectedRol.Id, IdPermiso = comboSelectedPermiso.Id });
                UpdateRelations();
            }
            catch (Exception ex)
            {
                MessageBox.Show(_exhandler.Handle(ex).Message);
            }
        }

        private void BtnBuscarPermisos_Click(object sender, EventArgs e)
        {
            try
            {
                GridPermisos.Clear();
                _rolePermissionManagementService.ObtenerListaDePermisos().ForEach(x => GridPermisos.Add(x));
            }
            catch (Exception ex)
            {

            }
        }

        private void BtnEliminarPermiso_Click(object sender, EventArgs e)
        {
            try
            {
                _rolePermissionManagementService.EliminarPermiso(selectedPermiso.Id);
                BtnBuscarPermisos.PerformClick();
            }
            catch (Exception ex)
            {

            }
        }

        private void BtnCrearPermiso_Click(object sender, EventArgs e)
        {
            try
            {
                _rolePermissionManagementService.CrearPermiso(new Permiso() { Codigo = TxtCodigoPermiso.Text });
                BtnBuscarPermisos.PerformClick();
            }
            catch (Exception ex)
            {

            }
        }

        private void BtnModificarPermiso_Click(object sender, EventArgs e)
        {
            try
            {
                _rolePermissionManagementService.ModificarPermiso(new Permiso(selectedPermiso.Id, TxtCodigoPermiso.Text));
                BtnBuscarPermisos.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show(_exhandler.Handle(ex).Message);
            }
        }
    }
}
