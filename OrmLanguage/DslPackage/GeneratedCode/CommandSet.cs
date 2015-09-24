﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DslShell = global::Microsoft.VisualStudio.Modeling.Shell;
using VSShell = global::Microsoft.VisualStudio.Shell;
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslDiagrams = global::Microsoft.VisualStudio.Modeling.Diagrams;
using DslValidation = global::Microsoft.VisualStudio.Modeling.Validation;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System;
using Microsoft.VisualStudio.Modeling.Shell;

namespace Company.OrmLanguage
{
	/// <summary>
	/// Double-derived class to allow easier code customization.
	/// </summary>
	internal partial class OrmLanguageCommandSet : OrmLanguageCommandSetBase
	{
        public Guid cmdViewSimpleOrmMappingRulesGuid = new Guid("EC120F9A-9E7F-469d-8D61-F4E2A97E5725");
        public const int cmdViewSimpleOrmMappingRulesId = 0x810;


        /// <summary>
        /// Constructs a new OrmLanguageCommandSet.
        /// </summary>
        public OrmLanguageCommandSet(global::System.IServiceProvider serviceProvider) 
			: base(serviceProvider)
		{
		}

        protected override IList<MenuCommand> GetMenuCommands()
        {
            var commands = base.GetMenuCommands();
            var cmdViewSimpleOrmMappingRules = new DynamicStatusMenuCommand(
                new EventHandler(OnPopUpMenuDisplayAction),
                new EventHandler(OnPopUpMenuClick),
                new CommandID(cmdViewSimpleOrmMappingRulesGuid, cmdViewSimpleOrmMappingRulesId));
            commands.Add(cmdViewSimpleOrmMappingRules);
            return commands;
        }

        internal void OnPopUpMenuDisplayAction(object sender, EventArgs args)
        {
            var command = sender as MenuCommand;
            foreach(var selectedObject in CurrentSelection)
            {
                if (selectedObject is EntityHasRelationShipsConnector)
                {
                    command.Visible = true;
                    command.Enabled = true;
                    return;
                }
            }

            command.Visible = false;
            command.Enabled = false;
        }

        internal void OnPopUpMenuClick(object sender, EventArgs args)
        {
            var command = sender as MenuCommand;
        }
    }

	/// <summary>
	/// Class containing handlers for commands supported by this DSL.
	/// </summary>
	internal abstract class OrmLanguageCommandSetBase : DslShell::CommandSet
	{
		/// <summary>
		/// Constructs a new OrmLanguageCommandSetBase.
		/// </summary>
		protected OrmLanguageCommandSetBase(global::System.IServiceProvider serviceProvider) : base(serviceProvider)
		{
		}

		/// <summary>
		/// Provide the menu commands that this command set handles
		/// </summary>
		protected override global::System.Collections.Generic.IList<global::System.ComponentModel.Design.MenuCommand> GetMenuCommands()
		{
			// Get the standard commands
			global::System.Collections.Generic.IList<global::System.ComponentModel.Design.MenuCommand> commands = base.GetMenuCommands();

			global::System.ComponentModel.Design.MenuCommand menuCommand;

			// Add command handler for the "view explorer" command in the top-level menu.
			// We use a ContextBoundMenuCommand because the visibility of this command is
			// based on whether or not the command context of our DSL editor is active. 
			menuCommand = new DslShell::CommandContextBoundMenuCommand(this.ServiceProvider,
				new global::System.EventHandler(OnMenuViewModelExplorer),
				Constants.ViewOrmLanguageExplorerCommand,
				typeof(OrmLanguageEditorFactory).GUID);

			commands.Add(menuCommand);

			return commands;
		}
		/// <summary>
		/// Command handler that shows the explorer tool window.
		/// </summary>
		internal virtual void OnMenuViewModelExplorer(object sender, global::System.EventArgs e)
		{
			OrmLanguageExplorerToolWindow explorer = this.OrmLanguageExplorerToolWindow;
			if (explorer != null)
			{
				explorer.Show();
			}
		}


		/// <summary>
		/// Returns the currently focused document.
		/// </summary>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		protected OrmLanguageDocData CurrentOrmLanguageDocData
		{
			get
			{
				return this.MonitorSelection.CurrentDocument as OrmLanguageDocData;
			}
		}

		/// <summary>
		/// Returns the currently focused document view.
		/// </summary>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		protected OrmLanguageDocView CurrentOrmLanguageDocView
		{
			get
			{
				return this.MonitorSelection.CurrentDocumentView as OrmLanguageDocView;
			}
		}

		/// <summary>
		/// Returns the explorer tool window.
		/// </summary>
		protected OrmLanguageExplorerToolWindow OrmLanguageExplorerToolWindow
		{
			get
			{
				OrmLanguageExplorerToolWindow explorerWindow = null;
				DslShell::ModelingPackage package = this.ServiceProvider.GetService(typeof(VSShell::Package)) as DslShell::ModelingPackage;

				if (package != null)
				{
					explorerWindow = package.GetToolWindow(typeof(OrmLanguageExplorerToolWindow), true) as OrmLanguageExplorerToolWindow;
				}

				return explorerWindow;
			}
		}

		/// <summary>
		/// Returns the currently selected object in the model explorer.
		/// </summary>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		protected object ExplorerSelection
		{
			get
			{
				object selection = null;
				OrmLanguageExplorerToolWindow explorerWindow = this.OrmLanguageExplorerToolWindow;
				
				if(explorerWindow != null)
				{
					foreach (object o in explorerWindow.GetSelectedComponents())
					{
						selection = o;
						break;
					}
				}

				return selection;
			}
		}
	}
	/// <summary>
	/// Double-derived class to allow easier code customization.
	/// </summary>
	internal partial class OrmLanguageClipboardCommandSet : OrmLanguageClipboardCommandSetBase
	{
		/// <summary>
		/// Constructs a new OrmLanguageClipboardCommandSet.
		/// </summary>
		public OrmLanguageClipboardCommandSet(global::System.IServiceProvider serviceProvider)
			: base(serviceProvider)
		{
		}
	}

	/// <summary>
	/// Class containing handlers for cut/copy/paste commands supported by this DSL.
	/// </summary>
	internal abstract partial class OrmLanguageClipboardCommandSetBase : DslShell::ClipboardCommandSet
	{
		/// <summary>
		/// Constructs a new OrmLanguageClipboardCommandSetBase.
		/// </summary>
		protected OrmLanguageClipboardCommandSetBase(global::System.IServiceProvider serviceProvider)
			: base(serviceProvider)
		{
		}

		/// <summary>
		/// Provide the menu commands that this command set handles
		/// </summary>
		protected override global::System.Collections.Generic.IList<global::System.ComponentModel.Design.MenuCommand> GetMenuCommands()
		{
			// Get the standard commands
			var commands = new global::System.Collections.Generic.List<global::System.ComponentModel.Design.MenuCommand>(3);

			global::System.ComponentModel.Design.MenuCommand menuCommand;

			menuCommand = new DslShell::DynamicStatusMenuCommand(
				new global::System.EventHandler(this.OnStatusCut),
				new global::System.EventHandler(this.OnMenuCut),
				global::System.ComponentModel.Design.StandardCommands.Cut);
			commands.Add(menuCommand);

			menuCommand = new DslShell::DynamicStatusMenuCommand(
				new global::System.EventHandler(this.OnStatusCopy),
				new global::System.EventHandler(this.OnMenuCopy),
				global::System.ComponentModel.Design.StandardCommands.Copy);
			commands.Add(menuCommand);

			menuCommand = new DslShell::DynamicStatusMenuCommand(
				new global::System.EventHandler(this.OnStatusPaste),
				new global::System.EventHandler(this.OnMenuPaste),
				global::System.ComponentModel.Design.StandardCommands.Paste);
			commands.Add(menuCommand);

			return commands;
		}

		/// <summary>
		/// Determines whether Cut menu item should be visible and if so, enabled.
		/// </summary>
		/// <param name="sender">The sender of the message</param>
		/// <param name="args">empty</param>
		private void OnStatusCut(object sender, global::System.EventArgs args)
		{
			System.ComponentModel.Design.MenuCommand cmd = sender as System.ComponentModel.Design.MenuCommand;
			this.ProcessOnStatusCutCommand(cmd);
		}

		/// <summary>
		/// Determines whether Copy menu item should be visible and if so, enabled.
		/// </summary>
		/// <param name="sender">The sender of the message</param>
		/// <param name="args">empty</param>
		private void OnStatusCopy(object sender, global::System.EventArgs args)
		{
			System.ComponentModel.Design.MenuCommand cmd = sender as System.ComponentModel.Design.MenuCommand;
			this.ProcessOnStatusCopyCommand(cmd);
		}

		/// <summary>
		/// Updates the UI for the Paste command
		/// </summary>
		/// <param name="sender">The sender of the message</param>
		/// <param name="args">Message parameters</param>
		private void OnStatusPaste(object sender, global::System.EventArgs args)
		{
			System.ComponentModel.Design.MenuCommand cmd = sender as System.ComponentModel.Design.MenuCommand;
			this.ProcessOnStatusPasteCommand(cmd);
		}

		/// <summary>
		/// Event handler to cut the selected objects to the clipboard then delete the original.
		/// </summary>
		/// <param name="sender">The MenuCommand selected.</param>
		/// <param name="args">not used</param>
		private void OnMenuCut(object sender, global::System.EventArgs args)
		{
			this.ProcessOnMenuCutCommand();
		}

		/// <summary>
		/// Event handler to copy the selected objects to the clipboard.
		/// </summary>
		/// <param name="sender">The MenuCommand selected.</param>
		/// <param name="args">not used</param>
		private void OnMenuCopy(object sender, global::System.EventArgs args)
		{
			this.ProcessOnMenuCopyCommand();
		}

		/// <summary>
		/// Event handler to paste a copy of the object on the clipboard.
		/// </summary>
		/// <param name="sender">The MenuCommand selected.</param>
		/// <param name="args">not used</param>
		private void OnMenuPaste(object sender, global::System.EventArgs args)
		{
			this.ProcessOnMenuPasteCommand();
		}
	}
}

