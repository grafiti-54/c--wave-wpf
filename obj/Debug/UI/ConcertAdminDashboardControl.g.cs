﻿#pragma checksum "..\..\..\UI\ConcertAdminDashboardControl.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "23FB70F9473D8831F24EBB3C570B5954369FEFBB6EB461FF96017A1F1F7A33BA"
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
    /// ConcertAdminDashboardControl
    /// </summary>
    public partial class ConcertAdminDashboardControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 12 "..\..\..\UI\ConcertAdminDashboardControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid datagridConcertAdmin;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\UI\ConcertAdminDashboardControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_address_concert;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\UI\ConcertAdminDashboardControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_date_concert;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\UI\ConcertAdminDashboardControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboboxAddGroupe;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\UI\ConcertAdminDashboardControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button add_concert_admin_btn;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\UI\ConcertAdminDashboardControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button update_concert_admin_btn;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\UI\ConcertAdminDashboardControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button delete_concert_admin_btn;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\UI\ConcertAdminDashboardControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button add_groupe_concert_admin_btn;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\UI\ConcertAdminDashboardControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_id_concert;
        
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
            System.Uri resourceLocater = new System.Uri("/WaveWpf;component/ui/concertadmindashboardcontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UI\ConcertAdminDashboardControl.xaml"
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
            this.datagridConcertAdmin = ((System.Windows.Controls.DataGrid)(target));
            
            #line 13 "..\..\..\UI\ConcertAdminDashboardControl.xaml"
            this.datagridConcertAdmin.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.getDataFromRowDataGrid);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 25 "..\..\..\UI\ConcertAdminDashboardControl.xaml"
            ((System.Windows.Controls.TextBox)(target)).TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SearchConcertAdmin);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txt_address_concert = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txt_date_concert = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.comboboxAddGroupe = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.add_concert_admin_btn = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\UI\ConcertAdminDashboardControl.xaml"
            this.add_concert_admin_btn.Click += new System.Windows.RoutedEventHandler(this.add_concert_admin_btn_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.update_concert_admin_btn = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\UI\ConcertAdminDashboardControl.xaml"
            this.update_concert_admin_btn.Click += new System.Windows.RoutedEventHandler(this.update_concert_admin_btn_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.delete_concert_admin_btn = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\UI\ConcertAdminDashboardControl.xaml"
            this.delete_concert_admin_btn.Click += new System.Windows.RoutedEventHandler(this.delete_concert_admin_btn_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.add_groupe_concert_admin_btn = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\UI\ConcertAdminDashboardControl.xaml"
            this.add_groupe_concert_admin_btn.Click += new System.Windows.RoutedEventHandler(this.add_groupe_concert_admin_btn_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.txt_id_concert = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 2:
            
            #line 19 "..\..\..\UI\ConcertAdminDashboardControl.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Detail_Concert_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}
