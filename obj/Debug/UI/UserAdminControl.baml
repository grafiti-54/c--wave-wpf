   M S B A M L   `   `   `  ����B  >WaveWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:WaveWpf.UI
WaveWpf.UI  5      !    WaveWpf.UI.UserAdminControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:WaveWpf.UI     5      .��5	      � ���	#FF3E4A67$	��420��6"   $	��785��6/   .+�5
   
   �� $#��Gestion role des utilisateurs��6   $��Center=�68   $��58��6\   $��Comic Sans MS)�6h   $��35(�6�   ���	#FFAEC5E4$��10,2,-10,360q�6�   �� 5   
   $%��/logo_wave-removebg-preview.png��6   $��13,2,595,362q�69   �� 5   
   -   5        $��txt_email_user_admin��5   �   $��16(�6   $��Center=�6    $
��Left=�6B   $��29��6]   $��
53,105,0,0q�6i     �� TextWrapping$
  Wrap=�6}   $	��Top=�6�   $	��275��6�   $��Comic Sans MS)�6�   {�.  6�   �� 5   
   $��0��6   $%��Adresse E-mail de l'utilisateur��6    $��Comic Sans MS)�6J   $��12(�6e   $��50,76,530,311q�6s   ���	#FFAEC5E46�   �� 5   
   -   5        $
��Left=�5      $��28��6-   $��531,198,0,0q�69   $
  Wrap=�6N   $	��Top=�6b   $	��200��6z   $��Comic Sans MS)�6�   $��14(�6�   6�   �� 5   
   $��0��6   $��
Rechercher��6    $��Comic Sans MS)�65   $��16(�6P   $��413,193,244,194q�6^   ���	#FFAEC5E46w   �� 5   
   -   5        $��checkbox_is_admin��5      $��Admin ?��6,   $
��Left=�6>   $��416,105,0,0q�6Y   $	��Top=�6n   $��29��6�   $	��112��6�   $��Comic Sans MS)�6�   $��16(�6�   ���	#FFAEC5E46�   �� 5   
   -   5         ��Name$ update_role_user��5      $��Modifier role��6+   $
��Left=�6C   $��
53,166,0,0q�6^   $	��Top=�6r   $	��135��6�   ���	#FF6BBFFF$��Comic Sans MS)�6�   $��16(�6�   $��42��6�    J� RenderTransformOrigin$ 0.457,1.195&�6  &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ datagridUsersList��5   1   $��Center=�6L   $	��151��6i   $��	0,245,0,0q�6v   $	��Top=�6�   $	��679��6�      AutoGenerateColumns .     CanUserAddRows .  ��6   �� *Users+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 66 6I   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 61   �� *id+6I     5      $ Email��6%   $	 465 6N   	 64   �� *Email+6N     5      $
 Role��6%   $	 140 6L   	 63   �� *Role+6L   5      �� 5   
   -   5        $ delete_user��5      $��	Supprimer��6&   $
��Left=�6:   $��193,166,0,0q�6U   $	��Top=�6j   $	��135��6�   ���	#FFF39595$��Comic Sans MS)�6�   $��16(�6�   $��42��6�   $ 0.457,1.195&�6�   �� 5   
   -   5        
 ��Name$
 txt_id_user_admin��5   �   $
��Left=�6   $��29��6-   $��
276,71,0,0q�69   $
  Wrap=�6M   $	��Top=�6b   $��52��6z   $��Comic Sans MS)�6�   $y�Hidden=�6�   5      5      