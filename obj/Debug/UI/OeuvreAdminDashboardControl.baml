   M S B A M L   `   `   `  ����B  >WaveWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:WaveWpf.UI
WaveWpf.UI  5      ,    &WaveWpf.UI.OeuvreAdminDashboardControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:WaveWpf.UI     5      .��5	      � ���	#FF3E4A67$	��420��6"   $	��785��6/   .+�5
   
   �� $��Gestion des oeuvres��6   $��Center=�6.   $��58��6R   $��Comic Sans MS)�6^   $��35(�6y   ���	#FFAEC5E4$��10,2,-10,360q�6�   �� 5   
   -   5        $
��Left=�5      $��28��6-   $��549,203,0,0q�69     �� TextWrapping$
  Wrap=�6N   $	��Top=�6b   $	��200��6z   $��Comic Sans MS)�6�   $��14(�6�   6�   �� 5   
   $��0��6   $��
Rechercher��6    $��Comic Sans MS)�65   $��16(�6P   $��433,198,224,189q�6^   ���	#FFAEC5E46w   �� 5   
   -   5         ��Name$ txt_title_oeuvre��5      $
��Left=�6,   $��21��6G   $��
37,104,0,0q�6S   $
  Wrap=�6g   $	��Top=�6|   $	��246��6�   $��Comic Sans MS)�6�   �� 5   
   $��0��6   $��Titre de l'oeuvre��6    $��Comic Sans MS)�6<   $��12(�6W   $��34,75,546,312q�6e   ���	#FFAEC5E46|   �� 5   
   -   5        $ txt_duree_oeuvre��5      $��Center=�6,   $��21��6I   $��	0,104,0,0q�6U   $
  Wrap=�6h   $	��Top=�6|   $	��133��6�   �� 5   
   $��0��6   $��Durée��6    $��Comic Sans MS)�60   $��12(�6K   $��324,76,256,311q�6Y   ���	#FFAEC5E46q   �� 5   
   $��0��6   $��Groupe��6    $��Comic Sans MS)�61   $��12(�6L   $��504,76,76,311q�6Z   ���	#FFAEC5E46q   �� 5   
   -   5         ��Name$ add_oeuvre_admin_btn��5      $��Ajouter��6/   $
��Left=�6A   $��
38,152,0,0q�6\   $	��Top=�6p   $��70��6�   ���	#FF6BBFFF$��Comic Sans MS)�6�   $��14(�6�   6�   �� 5   
   -   5        $ update_oeuvre_admin_btn��5      $��Modifier��62   $
��Left=�6E   $��119,152,0,0q�6`   $	��Top=�6u   $��79��6�   ���	#FFBAFF6B$��Comic Sans MS)�6�   $��14(�6�   6�   �� 5   
   -   5        $ delete_delete_admin_btn��5      $��	Supprimer��62   $
��Left=�6F   $��209,152,0,0q�6a   $	��Top=�6v   $��78��6�   ���	#FFF39595$��Comic Sans MS)�6�   $��14(�6�   6�   �� 5   
   -   5        $ txt_id_oeuvre��5      $
��Left=�6)   $��23��6D   $��308,141,0,0q�6P   $
  Wrap=�6e   $��TextBox��6y   $	��Top=�6�   $��66��6�   $y�Hidden=�6�   �� 5   
   -   5         ��Name$ comboboxAddGroupe��5      $
��Left=�6.   $��504,103,0,0q�6I   $	��Top=�6^   $	��245��6v    �� IsTextSearchEnabled .  �� Text$  Sélectionner un groupe...��6�   &   System.Windows.Controls.DataGrid  5   
   -	   5          Name$ datagridOeuvreListe��5      $��Center=�60   $	��149��6M   $��	0,246,0,0q�6Z   $	��Top=�6m   $	��714��6�      AutoGenerateColumns .     CanUserAddRows .  	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Id��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 65 6I   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+6I     5      $
 Titre��6%   $	 410 6O    64   �� *Title+6O     5      $
 Durée��6%   $	 125 6Q    64   �� *
Duration+6Q     5      $
 	Id Groupe��6%   $ 89 6U    68   �� *
IdGroupe+6U   5      �� 5   
   $%��/logo_wave-removebg-preview.png��6   $��35,0,573,364q�69   5       5!      