   M S B A M L   `   `   `  ���� B  >WaveWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:WaveWpf.UI
WaveWpf.UI  ,    &WaveWpf.UI.OeuvreAdminDashboardControl   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     *localclr-namespace:WaveWpf.UI     .��� ���	#FF3E4A67$	��420��$	��785��.+��� $��Gestion des oeuvres��$��Center=�$��58��$��Comic Sans MS)�$��35(����	#FFAEC5E4$��10,2,-10,360q��� -   $
��Left=�$��28��$��549,203,0,0q�  �� TextWrapping$
  Wrap=�$	��Top=�$	��200��$��Comic Sans MS)�$��14(��� $��0��$��
Rechercher��$��Comic Sans MS)�$��16(�$��433,198,224,189q����	#FFAEC5E4�� -    ��Name$ txt_title_oeuvre��$
��Left=�$��21��$��
37,104,0,0q�$
  Wrap=�$	��Top=�$	��246��$��Comic Sans MS)��� $��0��$��Titre de l'oeuvre��$��Comic Sans MS)�$��12(�$��34,75,546,312q����	#FFAEC5E4�� -   $ txt_duree_oeuvre��$��Center=�$��21��$��	0,104,0,0q�$
  Wrap=�$	��Top=�$	��133���� $��0��$��Durée��$��Comic Sans MS)�$��12(�$��324,76,256,311q����	#FFAEC5E4�� $��0��$��Groupe��$��Comic Sans MS)�$��12(�$��504,76,76,311q����	#FFAEC5E4�� -    ��Name$ add_oeuvre_admin_btn��$��Ajouter��$
��Left=�$��
38,152,0,0q�$	��Top=�$��70�����	#FF6BBFFF$��Comic Sans MS)�$��14(��� -   $ update_oeuvre_admin_btn��$��Modifier��$
��Left=�$��119,152,0,0q�$	��Top=�$��79�����	#FFBAFF6B$��Comic Sans MS)�$��14(��� -   $ delete_delete_admin_btn��$��	Supprimer��$
��Left=�$��209,152,0,0q�$	��Top=�$��78�����	#FFF39595$��Comic Sans MS)�$��14(��� -   $ txt_id_oeuvre��$
��Left=�$��23��$��308,141,0,0q�$
  Wrap=�$��TextBox��$	��Top=�$��66��$y�Hidden=��� -    ��Name$ comboboxAddGroupe��$
��Left=�$��504,103,0,0q�$	��Top=�$	��245�� �� IsTextSearchEnabled .  �� Text$  Sélectionner un groupe...��&   System.Windows.Controls.DataGrid  -	     Name$ datagridOeuvreListe��$��Center=�$	��149��$��	0,246,0,0q�$	��Top=�$	��714��   AutoGenerateColumns .     CanUserAddRows .  	   Columns	 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn
   Header$
 Id��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 65 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Id+  $
 Titre��$	 410  �� *Title+  $
 Durée��$	 125  �� *
Duration+  $
 	Id Groupe��$ 89  �� *
IdGroupe+�� $%��/logo_wave-removebg-preview.png��$��35,0,573,364q�