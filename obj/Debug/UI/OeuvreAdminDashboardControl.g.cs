﻿#pragma checksum "..\..\..\UI\OeuvreAdminDashboardControl.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "AE90C50C0193B081960D510D8D44481E16229816FF615B20F18703ABC56F89D4"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using WaveWpf.UI;


namespace WaveWpf.UI {
    
    
    /// <summary>
    /// OeuvreAdminDashboardControl
    /// </summary>
    public partial class OeuvreAdminDashboardControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\UI\OeuvreAdminDashboardControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_title_oeuvre;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\UI\OeuvreAdminDashboardControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_duree_oeuvre;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\UI\OeuvreAdminDashboardControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button add_oeuvre_admin_btn;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\UI\OeuvreAdminDashboardControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button update_oeuvre_admin_btn;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\UI\OeuvreAdminDashboardControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button delete_delete_admin_btn;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\UI\OeuvreAdminDashboardControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_id_oeuvre;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\UI\OeuvreAdminDashboardControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboboxAddGroupe;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\UI\OeuvreAdminDashboardControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid datagridOeuvreListe;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WaveWpf;component/ui/oeuvreadmindashboardcontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UI\OeuvreAdminDashboardControl.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 11 "..\..\..\UI\OeuvreAdminDashboardControl.xaml"
            ((System.Windows.Controls.TextBox)(target)).TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SearchOeuvreAdmin);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txt_title_oeuvre = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txt_duree_oeuvre = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.add_oeuvre_admin_btn = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\UI\OeuvreAdminDashboardControl.xaml"
            this.add_oeuvre_admin_btn.Click += new System.Windows.RoutedEventHandler(this.add_oeuvre_admin_btn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.update_oeuvre_admin_btn = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\UI\OeuvreAdminDashboardControl.xaml"
            this.update_oeuvre_admin_btn.Click += new System.Windows.RoutedEventHandler(this.update_oeuvre_admin_btn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.delete_delete_admin_btn = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\UI\OeuvreAdminDashboardControl.xaml"
            this.delete_delete_admin_btn.Click += new System.Windows.RoutedEventHandler(this.delete_oeuvre_admin_btn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.txt_id_oeuvre = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.comboboxAddGroupe = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.datagridOeuvreListe = ((System.Windows.Controls.DataGrid)(target));
            
            #line 23 "..\..\..\UI\OeuvreAdminDashboardControl.xaml"
            this.datagridOeuvreListe.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.getDataFromRowDataGrid);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

