﻿using System;
using System.Windows.Forms;

partial class Editor_Items : Form
{
    // Usado para acessar os dados da janela
    public static Editor_Items Objects = new Editor_Items();

    // Item selecionado
    private Lists.Structures.Item Selected;

    public Editor_Items()
    {
        InitializeComponent();
    }

    public static void Request()
    {
        // Lê os dados
        Globals.OpenEditor = Objects;
        Send.Request_Classes();
        Send.Request_Items();
    }

    public static void Open()
    {
        // Lista de classes
        Objects.cmbReq_Class.Items.Clear();
        Objects.cmbReq_Class.Items.Add("None");
        foreach (Lists.Structures.Class Class in Lists.Class.Values) Objects.cmbReq_Class.Items.Add(Class);

        // Lista de raridades
        Objects.cmbRarity.Items.Clear();
        for (byte i = 0; i < (byte)Globals.Rarity.Count; i++) Objects.cmbRarity.Items.Add((Globals.Rarity)i);

        // Lista de preensão
        Objects.cmbBind.Items.Clear();
        for (byte i = 0; i < (byte)Globals.BindOn.Count; i++) Objects.cmbBind.Items.Add((Globals.BindOn)i);

        // Define os limites
        Objects.numTexture.Maximum = Graphics.Tex_Item.GetUpperBound(0);

        // Lista os itens
        Objects.List.Nodes.Clear();
        foreach (Lists.Structures.Item Item in Lists.Item.Values)
        {
            Objects.List.Nodes.Add(Item.Name);
            Objects.List.Nodes[Objects.List.Nodes.Count - 1].Tag = Item.ID;
        }
        if (Objects.List.Nodes.Count > 0) Objects.List.SelectedNode = Objects.List.Nodes[0];

        // Abre a janela
        Selection.Objects.Visible = false;
        Objects.Visible = true;
    }

    private void Groups_Visibility()
    {
        // Atualiza a visiblidade dos paineis
        grpGeneral.Visible = grpRequirements.Visible = List.SelectedNode != null;
        grpEquipment.Visible = grpEquip_Bonus.Visible = grpPotion.Visible = false;
        List.Focus();
    }

    private void List_AfterSelect(object sender, TreeViewEventArgs e)
    {
        // Atualiza o valor da loja selecionada
        Selected = Lists.Item[(Guid)List.SelectedNode.Tag];

        // Altera a visibilidade dos grupos se necessário
        Groups_Visibility();

        // Lista os dados
        txtName.Text = Selected.Name;
        txtDescription.Text = Selected.Description;
        numTexture.Value = Selected.Texture;
        cmbType.SelectedIndex = Selected.Type;
        chkStackable.Checked = Selected.Stackable;
        cmbBind.SelectedIndex = Selected.Bind;
        cmbRarity.SelectedIndex = Selected.Rarity;
        numReq_Level.Value = Selected.Req_Level;
        if (Selected.Req_Class != null) cmbReq_Class.SelectedIndex = cmbReq_Class.Items.IndexOf(Selected.Req_Class);
        else cmbReq_Class.SelectedIndex = 0;
        numPotion_Experience.Value = Selected.Potion_Experience;
        numPotion_HP.Value = Selected.Potion_Vital[(byte)Globals.Vitals.HP];
        numPotion_MP.Value = Selected.Potion_Vital[(byte)Globals.Vitals.MP];
        cmbEquipment_Type.SelectedIndex = Selected.Equip_Type;
        numEquip_Strength.Value = Selected.Equip_Attribute[(byte)Globals.Attributes.Strength];
        numEquip_Resistance.Value = Selected.Equip_Attribute[(byte)Globals.Attributes.Resistance];
        numEquip_Intelligence.Value = Selected.Equip_Attribute[(byte)Globals.Attributes.Intelligence];
        numEquip_Agility.Value = Selected.Equip_Attribute[(byte)Globals.Attributes.Agility];
        numEquip_Vitality.Value = Selected.Equip_Attribute[(byte)Globals.Attributes.Vitality];
        numWeapon_Damage.Value = Selected.Weapon_Damage;
    }

    private void butNew_Click(object sender, EventArgs e)
    {
        // Adiciona uma loja nova
        Lists.Structures.Item Item = new Lists.Structures.Item(Guid.NewGuid());
        Item.Name = "New item";
        Lists.Item.Add(Item.ID, Item);

        // Adiciona na lista
        TreeNode Node = new TreeNode(Item.Name);
        Node.Tag = Item.ID;
        List.Nodes.Add(Node);
        List.SelectedNode = Node;
    }

    private void butRemove_Click(object sender, EventArgs e)
    {
        // Remove a loja selecionada
        if (List.SelectedNode != null)
        {
            Lists.Item.Remove(Selected.ID);
            List.SelectedNode.Remove();
            Groups_Visibility();
        }
    }

    private void butSave_Click(object sender, EventArgs e)
    {
        // Salva os dados
        Send.Write_Items();

        // Volta à janela de seleção
        Visible = false;
        Selection.Objects.Visible = true;
    }

    private void butCancel_Click(object sender, EventArgs e)
    {
        // Volta ao menu
        Visible = false;
        Selection.Objects.Visible = true;
    }

    private void txtName_TextChanged(object sender, EventArgs e)
    {
        // Atualiza a lista
        Selected.Name = txtName.Text;
        List.SelectedNode.Text = txtName.Text;
    }

    private void numTexture_ValueChanged(object sender, EventArgs e)
    {
        Selected.Texture = (short)numTexture.Value;
    }

    private void butTexture_Click(object sender, EventArgs e)
    {
        // Abre a pré visualização
        Selected.Texture = Preview.Select(Graphics.Tex_Item, Selected.Texture);
        numTexture.Value = Selected.Texture;
    }

    private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
    {
        Selected.Type = (byte)cmbType.SelectedIndex;

        // Visibilidade dos paineis
        if (cmbType.SelectedIndex == (byte)Globals.Items.Equipment) grpEquipment.Visible = true;
        else grpEquipment.Visible = false;
        if (cmbType.SelectedIndex == (byte)Globals.Items.Potion) grpPotion.Visible = true;
        else grpPotion.Visible = false;
    }

    private void numReq_Level_ValueChanged(object sender, EventArgs e)
    {
        Selected.Req_Level = (short)numReq_Level.Value;
    }

    private void cmbReq_Class_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbReq_Class.SelectedIndex == 0)
            Selected.Req_Class = null;
        else
            Selected.Req_Class = (Lists.Structures.Class)cmbReq_Class.SelectedItem;
    }

    private void numEquip_Vida_ValueChanged(object sender, EventArgs e)
    {
        Selected.Potion_Vital[(byte)Globals.Vitals.HP] = (short)numPotion_HP.Value;
    }

    private void numEquip_Mana_ValueChanged(object sender, EventArgs e)
    {
        Selected.Potion_Vital[(byte)Globals.Vitals.MP] = (short)numPotion_MP.Value;
    }

    private void numEquip_Experience_ValueChanged(object sender, EventArgs e)
    {
        Selected.Potion_Experience = (int)numPotion_Experience.Value;
    }

    private void numEquip_Strength_ValueChanged(object sender, EventArgs e)
    {
        Selected.Equip_Attribute[(byte)Globals.Attributes.Strength] = (short)numEquip_Strength.Value;
    }

    private void numEquip_Resistance_ValueChanged(object sender, EventArgs e)
    {
        Selected.Equip_Attribute[(byte)Globals.Attributes.Resistance] = (short)numEquip_Resistance.Value;
    }

    private void numEquip_Intelligence_ValueChanged(object sender, EventArgs e)
    {
        Selected.Equip_Attribute[(byte)Globals.Attributes.Intelligence] = (short)numEquip_Intelligence.Value;
    }

    private void numEquip_Agility_ValueChanged(object sender, EventArgs e)
    {
        Selected.Equip_Attribute[(byte)Globals.Attributes.Agility] = (short)numEquip_Agility.Value;
    }

    private void numEquip_Vitality_ValueChanged(object sender, EventArgs e)
    {
        Selected.Equip_Attribute[(byte)Globals.Attributes.Vitality] = (short)numEquip_Vitality.Value;
    }

    private void chkStackable_CheckedChanged(object sender, EventArgs e)
    {
        Selected.Stackable = chkStackable.Checked;
    }

    private void numWeapon_Damage_ValueChanged(object sender, EventArgs e)
    {
        Selected.Weapon_Damage = (short)numWeapon_Damage.Value;
    }

    private void cmbEquipment_Type_SelectedIndexChanged(object sender, EventArgs e)
    {
        Selected.Equip_Type = (byte)cmbEquipment_Type.SelectedIndex;
        numWeapon_Damage.Visible = lblWeapon_Damage.Visible = (cmbEquipment_Type.SelectedIndex == (byte)Globals.Equipments.Weapon);
    }

    private void txtDescription_TextChanged(object sender, EventArgs e)
    {
        Selected.Description = txtDescription.Text;
    }

    private void cmbRarity_SelectedIndexChanged(object sender, EventArgs e)
    {
        Selected.Rarity = (byte)cmbRarity.SelectedIndex;
    }

    private void cmbBind_SelectedIndexChanged(object sender, EventArgs e)
    {
        Selected.Bind = (byte)cmbBind.SelectedIndex;
    }
}