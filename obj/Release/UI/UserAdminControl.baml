   M S B A M L   `   `   `  ���� B  >WaveWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:WaveWpf.UI
WaveWpf.UI  !    WaveWpf.UI.UserAdminControl   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     *localclr-namespace:WaveWpf.UI     .��� ���	#FF3E4A67$	��420��$	��785��.+��� $#��Gestion role des utilisateurs��$��Center=�$��58��$��Comic Sans MS)�$��35(����	#FFAEC5E4$��10,2,-10,360q��� $%��/logo_wave-removebg-preview.png��$��13,2,595,362q��� -   $��txt_email_user_admin��$��16(�$��Center=�$
��Left=�$��29��$��
53,105,0,0q�  �� TextWrapping$
  Wrap=�$	��Top=�$	��275��$��Comic Sans MS)�{�.  �� $��0��$%��Adresse E-mail de l'utilisateur��$��Comic Sans MS)�$��12(�$��50,76,530,311q����	#FFAEC5E4�� -   $
��Left=�$��28��$��531,198,0,0q�$
  Wrap=�$	��Top=�$	��200��$��Comic Sans MS)�$��14(��� $��0��$��
Rechercher��$��Comic Sans MS)�$��16(�$��413,193,244,194q����	#FFAEC5E4�� -   $��checkbox_is_admin��$��Admin ?��$
��Left=�$��416,105,0,0q�$	��Top=�$��29��$	��112��$��Comic Sans MS)�$��16(����	#FFAEC5E4�� -    ��Name$ update_role_user��$��Modifier role��$
��Left=�$��
53,166,0,0q�$	��Top=�$	��135�����	#FF6BBFFF$��Comic Sans MS)�$��16(�$��42�� J� RenderTransformOrigin$ 0.457,1.195&�&   System.Windows.Controls.DataGrid  -     Name$ datagridUsersList��$��Center=�$	��151��$��	0,245,0,0q�$	��Top=�$	��679��   AutoGenerateColumns .     CanUserAddRows .  ���� *Users+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Id��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 66 1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 �� *id+  $ Email��$	 465 	 �� *Email+  $
 Role��$	 140 	 �� *Role+�� -   $ delete_user��$��	Supprimer��$
��Left=�$��193,166,0,0q�$	��Top=�$	��135�����	#FFF39595$��Comic Sans MS)�$��16(�$��42��$ 0.457,1.195&��� -   
 ��Name$
 txt_id_user_admin��$
��Left=�$��29��$��
276,71,0,0q�$
  Wrap=�$	��Top=�$��52��$��Comic Sans MS)�$y�Hidden=�