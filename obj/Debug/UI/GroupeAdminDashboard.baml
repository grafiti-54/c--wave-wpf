   M S B A M L   `   `   `  ����B  >WaveWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:WaveWpf.UI
WaveWpf.UI  5      %    WaveWpf.UI.GroupeAdminDashboard   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:WaveWpf.UI     5      .��5	      � ���	#FF3E4A67$	��420��6"   $	��785��6/   .+�5
   
   �� $��Gestion des groupes��6   $��Center=�6.   $��58��6R   $��Comic Sans MS)�6^   $��35(�6y   ���	#FFAEC5E4$��10,2,-10,360q�6�   �� 5   
   -   5        $
��Left=�5      $��28��6-   $��549,203,0,0q�69     �� TextWrapping$
  Wrap=�6N   $	��Top=�6b   $	��200��6z   $��Comic Sans MS)�6�   $��14(�6�   6�   �� 5   
   $��0��6   $��
Rechercher��6    $��Comic Sans MS)�65   $��16(�6P   $��433,198,224,189q�6^   ���	#FFAEC5E46w   �� 5   
   -   5        $��txt_name_groupe��5      $
��Left=�6)   $��21��6D   $��
37,104,0,0q�6P   $
  Wrap=�6d   $	��Top=�6y   $	��246��6�   $��Comic Sans MS)�6�   �� 5   
   $��0��6   $��Nom du groupe��6    $��Comic Sans MS)�68   $��12(�6S   $��34,75,546,312q�6a   ���	#FFAEC5E46x   �� 5   
   -   5        $��txt_address_groupe��5      $
��Left=�6,   $��21��6G   $��308,104,0,0q�6S   $
  Wrap=�6h   $	��Top=�6|   $	��209��6�   �� 5   
   $��0��6   $��Adresse de contact��6    $��Comic Sans MS)�6=   $��12(�6X   $��308,76,272,311q�6f   ���	#FFAEC5E46~   �� 5   
   $��0��6   $��N° Téléphone��6    $��Comic Sans MS)�67   $��12(�6R   $��544,76,36,311q�6`   ���	#FFAEC5E46w   �� 5   
   -   5        $��add_groupe_admin_btn��5      $��Ajouter��6-   $
��Left=�6?   $��
38,152,0,0q�6Z   $	��Top=�6n   $��70��6�   ���	#FF6BBFFF$��Comic Sans MS)�6�   $��14(�6�   6�   �� 5   
   -   5        $��update_groupe_admin_btn��5      $��Modifier��60   $
��Left=�6C   $��119,152,0,0q�6^   $	��Top=�6s   $��79��6�   ���	#FFBAFF6B$��Comic Sans MS)�6�   $��14(�6�   6�   �� 5   
   -   5        $��delete_groupe_admin_btn��5      $��	Supprimer��60   $
��Left=�6D   $��209,152,0,0q�6_   $	��Top=�6t   $��78��6�   ���	#FFF39595$��Comic Sans MS)�6�   $��14(�6�   6�   �� 5   
   -   5         ��Name$ txt_id_groupe��5      $
��Left=�6)   $��23��6D   $��308,141,0,0q�6P   $
  Wrap=�6e   $��TextBox��6y   $	��Top=�6�   $��66��6�   $y�Hidden=�6�   �� 5   
   -   5        $��txt_phone_groupe��5      $
��Left=�6*   $��21��6E   $��549,104,0,0q�6Q   $
  Wrap=�6f   $	��Top=�6z   $	��200��6�   &   System.Windows.Controls.DataGrid  5   
   -	   5          Name$ datagridGroupeAdmin��5      $��Center=�60   $	��147��6M   $��	0,245,0,0q�6Z   $	��Top=�6m   $	��713��6�   $��Comic Sans MS)�5   +      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6F      CanUserAddRows .  ��6   �� *	Groupes+   Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5         CellTemplate 5      �� 5      .R�5      �� -
   5        $��Détails��5   %   67   5       5"      5$      �� 5%   
   $%��/logo_wave-removebg-preview.png��6   $��35,0,573,364q�69   5'      5(      