namespace Library
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.books = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.AddBookButton = new System.Windows.Forms.ToolStripButton();
            this.DeleteBookButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.InfoBookButton = new System.Windows.Forms.ToolStripButton();
            this.readers = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.bindingNavigator2 = new System.Windows.Forms.BindingNavigator(this.components);
            this.AddReaderButton = new System.Windows.Forms.ToolStripButton();
            this.DeleteReaderButton = new System.Windows.Forms.ToolStripButton();
            this.EditReaderButton = new System.Windows.Forms.ToolStripButton();
            this.authors = new System.Windows.Forms.TabPage();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.bindingNavigator3 = new System.Windows.Forms.BindingNavigator(this.components);
            this.AddAuthorButton = new System.Windows.Forms.ToolStripButton();
            this.DeleteAuthorButton = new System.Windows.Forms.ToolStripButton();
            this.EditAuthorButton = new System.Windows.Forms.ToolStripButton();
            this.genres = new System.Windows.Forms.TabPage();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.bindingNavigator4 = new System.Windows.Forms.BindingNavigator(this.components);
            this.AddGenreButton = new System.Windows.Forms.ToolStripButton();
            this.DeleteGenreButton = new System.Windows.Forms.ToolStripButton();
            this.EditGenreButton = new System.Windows.Forms.ToolStripButton();
            this.publishings = new System.Windows.Forms.TabPage();
            this.dataGridView5 = new System.Windows.Forms.DataGridView();
            this.bindingNavigator5 = new System.Windows.Forms.BindingNavigator(this.components);
            this.AddPublishingButton = new System.Windows.Forms.ToolStripButton();
            this.DeletePublishingButton = new System.Windows.Forms.ToolStripButton();
            this.EditPublishingButton = new System.Windows.Forms.ToolStripButton();
            this.rooms = new System.Windows.Forms.TabPage();
            this.dataGridView6 = new System.Windows.Forms.DataGridView();
            this.bindingNavigator6 = new System.Windows.Forms.BindingNavigator(this.components);
            this.AddRoomButton = new System.Windows.Forms.ToolStripButton();
            this.DeleteRoomButton = new System.Windows.Forms.ToolStripButton();
            this.EditRoomButton = new System.Windows.Forms.ToolStripButton();
            this.tabControl1.SuspendLayout();
            this.books.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.readers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator2)).BeginInit();
            this.bindingNavigator2.SuspendLayout();
            this.authors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator3)).BeginInit();
            this.bindingNavigator3.SuspendLayout();
            this.genres.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator4)).BeginInit();
            this.bindingNavigator4.SuspendLayout();
            this.publishings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator5)).BeginInit();
            this.bindingNavigator5.SuspendLayout();
            this.rooms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator6)).BeginInit();
            this.bindingNavigator6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.books);
            this.tabControl1.Controls.Add(this.readers);
            this.tabControl1.Controls.Add(this.authors);
            this.tabControl1.Controls.Add(this.genres);
            this.tabControl1.Controls.Add(this.publishings);
            this.tabControl1.Controls.Add(this.rooms);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 450);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.TabChanged);
            // 
            // books
            // 
            this.books.Controls.Add(this.dataGridView1);
            this.books.Controls.Add(this.bindingNavigator1);
            this.books.Location = new System.Drawing.Point(4, 22);
            this.books.Name = "books";
            this.books.Padding = new System.Windows.Forms.Padding(3);
            this.books.Size = new System.Drawing.Size(792, 424);
            this.books.TabIndex = 0;
            this.books.Text = "Книги";
            this.books.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(786, 393);
            this.dataGridView1.TabIndex = 1;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.CountItem = null;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddBookButton,
            this.DeleteBookButton,
            this.toolStripButton1,
            this.InfoBookButton});
            this.bindingNavigator1.Location = new System.Drawing.Point(3, 3);
            this.bindingNavigator1.MoveFirstItem = null;
            this.bindingNavigator1.MoveLastItem = null;
            this.bindingNavigator1.MoveNextItem = null;
            this.bindingNavigator1.MovePreviousItem = null;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = null;
            this.bindingNavigator1.Size = new System.Drawing.Size(786, 25);
            this.bindingNavigator1.TabIndex = 2;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // AddBookButton
            // 
            this.AddBookButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.AddBookButton.Image = ((System.Drawing.Image)(resources.GetObject("AddBookButton.Image")));
            this.AddBookButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddBookButton.Name = "AddBookButton";
            this.AddBookButton.Size = new System.Drawing.Size(63, 22);
            this.AddBookButton.Text = "Добавить";
            this.AddBookButton.Click += new System.EventHandler(this.AddBookButton_Click);
            // 
            // DeleteBookButton
            // 
            this.DeleteBookButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.DeleteBookButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteBookButton.Image")));
            this.DeleteBookButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteBookButton.Name = "DeleteBookButton";
            this.DeleteBookButton.Size = new System.Drawing.Size(55, 22);
            this.DeleteBookButton.Text = "Удалить";
            this.DeleteBookButton.Click += new System.EventHandler(this.DeleteBookButton_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(65, 22);
            this.toolStripButton1.Text = "Изменить";
            this.toolStripButton1.Click += new System.EventHandler(this.EditBookButton);
            // 
            // InfoBookButton
            // 
            this.InfoBookButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.InfoBookButton.Image = ((System.Drawing.Image)(resources.GetObject("InfoBookButton.Image")));
            this.InfoBookButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.InfoBookButton.Name = "InfoBookButton";
            this.InfoBookButton.Size = new System.Drawing.Size(73, 22);
            this.InfoBookButton.Text = "Подробнее";
            this.InfoBookButton.Click += new System.EventHandler(this.InfoBookButton_Click);
            // 
            // readers
            // 
            this.readers.Controls.Add(this.dataGridView2);
            this.readers.Controls.Add(this.bindingNavigator2);
            this.readers.Location = new System.Drawing.Point(4, 22);
            this.readers.Name = "readers";
            this.readers.Padding = new System.Windows.Forms.Padding(3);
            this.readers.Size = new System.Drawing.Size(792, 424);
            this.readers.TabIndex = 1;
            this.readers.Text = "Читатели";
            this.readers.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(3, 28);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(786, 393);
            this.dataGridView2.TabIndex = 3;
            // 
            // bindingNavigator2
            // 
            this.bindingNavigator2.AddNewItem = null;
            this.bindingNavigator2.CountItem = null;
            this.bindingNavigator2.DeleteItem = null;
            this.bindingNavigator2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddReaderButton,
            this.DeleteReaderButton,
            this.EditReaderButton});
            this.bindingNavigator2.Location = new System.Drawing.Point(3, 3);
            this.bindingNavigator2.MoveFirstItem = null;
            this.bindingNavigator2.MoveLastItem = null;
            this.bindingNavigator2.MoveNextItem = null;
            this.bindingNavigator2.MovePreviousItem = null;
            this.bindingNavigator2.Name = "bindingNavigator2";
            this.bindingNavigator2.PositionItem = null;
            this.bindingNavigator2.Size = new System.Drawing.Size(786, 25);
            this.bindingNavigator2.TabIndex = 4;
            this.bindingNavigator2.Text = "bindingNavigator2";
            // 
            // AddReaderButton
            // 
            this.AddReaderButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.AddReaderButton.Image = ((System.Drawing.Image)(resources.GetObject("AddReaderButton.Image")));
            this.AddReaderButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddReaderButton.Name = "AddReaderButton";
            this.AddReaderButton.Size = new System.Drawing.Size(63, 22);
            this.AddReaderButton.Text = "Добавить";
            this.AddReaderButton.Click += new System.EventHandler(this.AddReaderButton_Click);
            // 
            // DeleteReaderButton
            // 
            this.DeleteReaderButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.DeleteReaderButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteReaderButton.Image")));
            this.DeleteReaderButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteReaderButton.Name = "DeleteReaderButton";
            this.DeleteReaderButton.Size = new System.Drawing.Size(55, 22);
            this.DeleteReaderButton.Text = "Удалить";
            this.DeleteReaderButton.Click += new System.EventHandler(this.DeleteReaderButton_Click);
            // 
            // EditReaderButton
            // 
            this.EditReaderButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.EditReaderButton.Image = ((System.Drawing.Image)(resources.GetObject("EditReaderButton.Image")));
            this.EditReaderButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditReaderButton.Name = "EditReaderButton";
            this.EditReaderButton.Size = new System.Drawing.Size(65, 22);
            this.EditReaderButton.Text = "Изменить";
            this.EditReaderButton.Click += new System.EventHandler(this.EditReaderButton_Click);
            // 
            // authors
            // 
            this.authors.Controls.Add(this.dataGridView3);
            this.authors.Controls.Add(this.bindingNavigator3);
            this.authors.Location = new System.Drawing.Point(4, 22);
            this.authors.Name = "authors";
            this.authors.Size = new System.Drawing.Size(792, 424);
            this.authors.TabIndex = 2;
            this.authors.Text = "Авторы";
            this.authors.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView3.Location = new System.Drawing.Point(0, 25);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView3.Size = new System.Drawing.Size(792, 399);
            this.dataGridView3.TabIndex = 3;
            // 
            // bindingNavigator3
            // 
            this.bindingNavigator3.AddNewItem = null;
            this.bindingNavigator3.CountItem = null;
            this.bindingNavigator3.DeleteItem = null;
            this.bindingNavigator3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddAuthorButton,
            this.DeleteAuthorButton,
            this.EditAuthorButton});
            this.bindingNavigator3.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator3.MoveFirstItem = null;
            this.bindingNavigator3.MoveLastItem = null;
            this.bindingNavigator3.MoveNextItem = null;
            this.bindingNavigator3.MovePreviousItem = null;
            this.bindingNavigator3.Name = "bindingNavigator3";
            this.bindingNavigator3.PositionItem = null;
            this.bindingNavigator3.Size = new System.Drawing.Size(792, 25);
            this.bindingNavigator3.TabIndex = 4;
            this.bindingNavigator3.Text = "bindingNavigator3";
            // 
            // AddAuthorButton
            // 
            this.AddAuthorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.AddAuthorButton.Image = ((System.Drawing.Image)(resources.GetObject("AddAuthorButton.Image")));
            this.AddAuthorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddAuthorButton.Name = "AddAuthorButton";
            this.AddAuthorButton.Size = new System.Drawing.Size(63, 22);
            this.AddAuthorButton.Text = "Добавить";
            this.AddAuthorButton.Click += new System.EventHandler(this.AddAuthorButton_Click);
            // 
            // DeleteAuthorButton
            // 
            this.DeleteAuthorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.DeleteAuthorButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteAuthorButton.Image")));
            this.DeleteAuthorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteAuthorButton.Name = "DeleteAuthorButton";
            this.DeleteAuthorButton.Size = new System.Drawing.Size(55, 22);
            this.DeleteAuthorButton.Text = "Удалить";
            this.DeleteAuthorButton.Click += new System.EventHandler(this.DeleteAuthorButton_Click);
            // 
            // EditAuthorButton
            // 
            this.EditAuthorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.EditAuthorButton.Image = ((System.Drawing.Image)(resources.GetObject("EditAuthorButton.Image")));
            this.EditAuthorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditAuthorButton.Name = "EditAuthorButton";
            this.EditAuthorButton.Size = new System.Drawing.Size(65, 22);
            this.EditAuthorButton.Text = "Изменить";
            this.EditAuthorButton.Click += new System.EventHandler(this.EditAuthorButton_Click);
            // 
            // genres
            // 
            this.genres.Controls.Add(this.dataGridView4);
            this.genres.Controls.Add(this.bindingNavigator4);
            this.genres.Location = new System.Drawing.Point(4, 22);
            this.genres.Name = "genres";
            this.genres.Size = new System.Drawing.Size(792, 424);
            this.genres.TabIndex = 3;
            this.genres.Text = "Жанры";
            this.genres.UseVisualStyleBackColor = true;
            // 
            // dataGridView4
            // 
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView4.Location = new System.Drawing.Point(0, 25);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView4.Size = new System.Drawing.Size(792, 399);
            this.dataGridView4.TabIndex = 3;
            // 
            // bindingNavigator4
            // 
            this.bindingNavigator4.AddNewItem = null;
            this.bindingNavigator4.CountItem = null;
            this.bindingNavigator4.DeleteItem = null;
            this.bindingNavigator4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddGenreButton,
            this.DeleteGenreButton,
            this.EditGenreButton});
            this.bindingNavigator4.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator4.MoveFirstItem = null;
            this.bindingNavigator4.MoveLastItem = null;
            this.bindingNavigator4.MoveNextItem = null;
            this.bindingNavigator4.MovePreviousItem = null;
            this.bindingNavigator4.Name = "bindingNavigator4";
            this.bindingNavigator4.PositionItem = null;
            this.bindingNavigator4.Size = new System.Drawing.Size(792, 25);
            this.bindingNavigator4.TabIndex = 4;
            this.bindingNavigator4.Text = "bindingNavigator4";
            // 
            // AddGenreButton
            // 
            this.AddGenreButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.AddGenreButton.Image = ((System.Drawing.Image)(resources.GetObject("AddGenreButton.Image")));
            this.AddGenreButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddGenreButton.Name = "AddGenreButton";
            this.AddGenreButton.Size = new System.Drawing.Size(63, 22);
            this.AddGenreButton.Text = "Добавить";
            this.AddGenreButton.Click += new System.EventHandler(this.AddGenreButton_Click);
            // 
            // DeleteGenreButton
            // 
            this.DeleteGenreButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.DeleteGenreButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteGenreButton.Image")));
            this.DeleteGenreButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteGenreButton.Name = "DeleteGenreButton";
            this.DeleteGenreButton.Size = new System.Drawing.Size(55, 22);
            this.DeleteGenreButton.Text = "Удалить";
            this.DeleteGenreButton.Click += new System.EventHandler(this.DeleteGenreButton_Click);
            // 
            // EditGenreButton
            // 
            this.EditGenreButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.EditGenreButton.Image = ((System.Drawing.Image)(resources.GetObject("EditGenreButton.Image")));
            this.EditGenreButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditGenreButton.Name = "EditGenreButton";
            this.EditGenreButton.Size = new System.Drawing.Size(65, 22);
            this.EditGenreButton.Text = "Изменить";
            this.EditGenreButton.Click += new System.EventHandler(this.EditGenreButton_Click);
            // 
            // publishings
            // 
            this.publishings.Controls.Add(this.dataGridView5);
            this.publishings.Controls.Add(this.bindingNavigator5);
            this.publishings.Location = new System.Drawing.Point(4, 22);
            this.publishings.Name = "publishings";
            this.publishings.Size = new System.Drawing.Size(792, 424);
            this.publishings.TabIndex = 4;
            this.publishings.Text = "Издательства";
            this.publishings.UseVisualStyleBackColor = true;
            // 
            // dataGridView5
            // 
            this.dataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView5.Location = new System.Drawing.Point(0, 25);
            this.dataGridView5.Name = "dataGridView5";
            this.dataGridView5.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView5.Size = new System.Drawing.Size(792, 399);
            this.dataGridView5.TabIndex = 3;
            // 
            // bindingNavigator5
            // 
            this.bindingNavigator5.AddNewItem = null;
            this.bindingNavigator5.CountItem = null;
            this.bindingNavigator5.DeleteItem = null;
            this.bindingNavigator5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddPublishingButton,
            this.DeletePublishingButton,
            this.EditPublishingButton});
            this.bindingNavigator5.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator5.MoveFirstItem = null;
            this.bindingNavigator5.MoveLastItem = null;
            this.bindingNavigator5.MoveNextItem = null;
            this.bindingNavigator5.MovePreviousItem = null;
            this.bindingNavigator5.Name = "bindingNavigator5";
            this.bindingNavigator5.PositionItem = null;
            this.bindingNavigator5.Size = new System.Drawing.Size(792, 25);
            this.bindingNavigator5.TabIndex = 4;
            this.bindingNavigator5.Text = "bindingNavigator5";
            // 
            // AddPublishingButton
            // 
            this.AddPublishingButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.AddPublishingButton.Image = ((System.Drawing.Image)(resources.GetObject("AddPublishingButton.Image")));
            this.AddPublishingButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddPublishingButton.Name = "AddPublishingButton";
            this.AddPublishingButton.Size = new System.Drawing.Size(63, 22);
            this.AddPublishingButton.Text = "Добавить";
            this.AddPublishingButton.Click += new System.EventHandler(this.AddPublishingButton_Click);
            // 
            // DeletePublishingButton
            // 
            this.DeletePublishingButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.DeletePublishingButton.Image = ((System.Drawing.Image)(resources.GetObject("DeletePublishingButton.Image")));
            this.DeletePublishingButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeletePublishingButton.Name = "DeletePublishingButton";
            this.DeletePublishingButton.Size = new System.Drawing.Size(55, 22);
            this.DeletePublishingButton.Text = "Удалить";
            this.DeletePublishingButton.Click += new System.EventHandler(this.DeletePublishingButton_Click);
            // 
            // EditPublishingButton
            // 
            this.EditPublishingButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.EditPublishingButton.Image = ((System.Drawing.Image)(resources.GetObject("EditPublishingButton.Image")));
            this.EditPublishingButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditPublishingButton.Name = "EditPublishingButton";
            this.EditPublishingButton.Size = new System.Drawing.Size(65, 22);
            this.EditPublishingButton.Text = "Изменить";
            this.EditPublishingButton.Click += new System.EventHandler(this.EditPublishingButton_Click);
            // 
            // rooms
            // 
            this.rooms.Controls.Add(this.dataGridView6);
            this.rooms.Controls.Add(this.bindingNavigator6);
            this.rooms.Location = new System.Drawing.Point(4, 22);
            this.rooms.Name = "rooms";
            this.rooms.Size = new System.Drawing.Size(792, 424);
            this.rooms.TabIndex = 5;
            this.rooms.Text = "Читальные залы";
            this.rooms.UseVisualStyleBackColor = true;
            // 
            // dataGridView6
            // 
            this.dataGridView6.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView6.Location = new System.Drawing.Point(0, 25);
            this.dataGridView6.Name = "dataGridView6";
            this.dataGridView6.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView6.Size = new System.Drawing.Size(792, 399);
            this.dataGridView6.TabIndex = 3;
            // 
            // bindingNavigator6
            // 
            this.bindingNavigator6.AddNewItem = null;
            this.bindingNavigator6.CountItem = null;
            this.bindingNavigator6.DeleteItem = null;
            this.bindingNavigator6.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddRoomButton,
            this.DeleteRoomButton,
            this.EditRoomButton});
            this.bindingNavigator6.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator6.MoveFirstItem = null;
            this.bindingNavigator6.MoveLastItem = null;
            this.bindingNavigator6.MoveNextItem = null;
            this.bindingNavigator6.MovePreviousItem = null;
            this.bindingNavigator6.Name = "bindingNavigator6";
            this.bindingNavigator6.PositionItem = null;
            this.bindingNavigator6.Size = new System.Drawing.Size(792, 25);
            this.bindingNavigator6.TabIndex = 4;
            this.bindingNavigator6.Text = "bindingNavigator6";
            // 
            // AddRoomButton
            // 
            this.AddRoomButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.AddRoomButton.Image = ((System.Drawing.Image)(resources.GetObject("AddRoomButton.Image")));
            this.AddRoomButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddRoomButton.Name = "AddRoomButton";
            this.AddRoomButton.Size = new System.Drawing.Size(63, 22);
            this.AddRoomButton.Text = "Добавить";
            this.AddRoomButton.Click += new System.EventHandler(this.AddRoomButton_Click);
            // 
            // DeleteRoomButton
            // 
            this.DeleteRoomButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.DeleteRoomButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteRoomButton.Image")));
            this.DeleteRoomButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteRoomButton.Name = "DeleteRoomButton";
            this.DeleteRoomButton.Size = new System.Drawing.Size(55, 22);
            this.DeleteRoomButton.Text = "Удалить";
            this.DeleteRoomButton.Click += new System.EventHandler(this.DeleteRoomButton_Click);
            // 
            // EditRoomButton
            // 
            this.EditRoomButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.EditRoomButton.Image = ((System.Drawing.Image)(resources.GetObject("EditRoomButton.Image")));
            this.EditRoomButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditRoomButton.Name = "EditRoomButton";
            this.EditRoomButton.Size = new System.Drawing.Size(65, 22);
            this.EditRoomButton.Text = "Изменить";
            this.EditRoomButton.Click += new System.EventHandler(this.EditRoomButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "Library - Главная страница";
            this.tabControl1.ResumeLayout(false);
            this.books.ResumeLayout(false);
            this.books.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.readers.ResumeLayout(false);
            this.readers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator2)).EndInit();
            this.bindingNavigator2.ResumeLayout(false);
            this.bindingNavigator2.PerformLayout();
            this.authors.ResumeLayout(false);
            this.authors.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator3)).EndInit();
            this.bindingNavigator3.ResumeLayout(false);
            this.bindingNavigator3.PerformLayout();
            this.genres.ResumeLayout(false);
            this.genres.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator4)).EndInit();
            this.bindingNavigator4.ResumeLayout(false);
            this.bindingNavigator4.PerformLayout();
            this.publishings.ResumeLayout(false);
            this.publishings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator5)).EndInit();
            this.bindingNavigator5.ResumeLayout(false);
            this.bindingNavigator5.PerformLayout();
            this.rooms.ResumeLayout(false);
            this.rooms.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator6)).EndInit();
            this.bindingNavigator6.ResumeLayout(false);
            this.bindingNavigator6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage books;
        private System.Windows.Forms.TabPage readers;
        private System.Windows.Forms.TabPage authors;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton AddBookButton;
        private System.Windows.Forms.ToolStripButton DeleteBookButton;
        private System.Windows.Forms.ToolStripButton InfoBookButton;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.BindingNavigator bindingNavigator2;
        private System.Windows.Forms.ToolStripButton AddReaderButton;
        private System.Windows.Forms.ToolStripButton DeleteReaderButton;
        private System.Windows.Forms.ToolStripButton EditReaderButton;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.BindingNavigator bindingNavigator3;
        private System.Windows.Forms.ToolStripButton AddAuthorButton;
        private System.Windows.Forms.ToolStripButton DeleteAuthorButton;
        private System.Windows.Forms.ToolStripButton EditAuthorButton;
        private System.Windows.Forms.TabPage genres;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.BindingNavigator bindingNavigator4;
        private System.Windows.Forms.ToolStripButton AddGenreButton;
        private System.Windows.Forms.ToolStripButton DeleteGenreButton;
        private System.Windows.Forms.ToolStripButton EditGenreButton;
        private System.Windows.Forms.TabPage publishings;
        private System.Windows.Forms.DataGridView dataGridView5;
        private System.Windows.Forms.BindingNavigator bindingNavigator5;
        private System.Windows.Forms.ToolStripButton AddPublishingButton;
        private System.Windows.Forms.ToolStripButton DeletePublishingButton;
        private System.Windows.Forms.ToolStripButton EditPublishingButton;
        private System.Windows.Forms.TabPage rooms;
        private System.Windows.Forms.DataGridView dataGridView6;
        private System.Windows.Forms.BindingNavigator bindingNavigator6;
        private System.Windows.Forms.ToolStripButton AddRoomButton;
        private System.Windows.Forms.ToolStripButton DeleteRoomButton;
        private System.Windows.Forms.ToolStripButton EditRoomButton;
    }
}

