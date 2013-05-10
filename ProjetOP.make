

# Warning: This is an automatically generated file, do not edit!

srcdir=.
top_srcdir=.

include $(top_srcdir)/config.make

ifeq ($(CONFIG),DEBUG_X86)
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug "-define:DEBUG;"
ASSEMBLY = bin/Debug/SpaceGame.exe
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = exe
PROJECT_REFERENCES = 
BUILD_DIR = bin/Debug

SPACEGAME_EXE_MDB_SOURCE=bin/Debug/SpaceGame.exe.mdb
SPACEGAME_EXE_MDB=$(BUILD_DIR)/SpaceGame.exe.mdb
GAMEPADBRIDGE_DLL_SOURCE=Externals/GamepadBridge.dll
TAO_SDL_DLL_SOURCE=Externals/Tao.Sdl.dll
GAMEPADCONFIGCONTROLS_DLL_SOURCE=Externals/GamepadConfigControls.dll
LIDGREN_NETWORK_DLL_SOURCE=Externals/Lidgren.Network.dll
OPENTK_DLL_SOURCE=Externals/OpenTK.dll
MONOGAME_FRAMEWORK_LINUX_DLL_SOURCE=Externals/MonoGame.Framework.Linux.dll

endif

ifeq ($(CONFIG),RELEASE_X86)
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize-
ASSEMBLY = bin/Release/SpaceGame.exe
ASSEMBLY_MDB = 
COMPILE_TARGET = exe
PROJECT_REFERENCES = 
BUILD_DIR = bin/Release

SPACEGAME_EXE_MDB=
GAMEPADBRIDGE_DLL_SOURCE=Externals/GamepadBridge.dll
TAO_SDL_DLL_SOURCE=Externals/Tao.Sdl.dll
GAMEPADCONFIGCONTROLS_DLL_SOURCE=Externals/GamepadConfigControls.dll
LIDGREN_NETWORK_DLL_SOURCE=Externals/Lidgren.Network.dll
OPENTK_DLL_SOURCE=Externals/OpenTK.dll
MONOGAME_FRAMEWORK_LINUX_DLL_SOURCE=Externals/MonoGame.Framework.Linux.dll

endif

AL=al
SATELLITE_ASSEMBLY_NAME=$(notdir $(basename $(ASSEMBLY))).resources.dll

PROGRAMFILES = \
	$(SPACEGAME_EXE_MDB) \
	$(GAMEPADBRIDGE_DLL) \
	$(TAO_SDL_DLL) \
	$(GAMEPADCONFIGCONTROLS_DLL) \
	$(LIDGREN_NETWORK_DLL) \
	$(OPENTK_DLL) \
	$(MONOGAME_FRAMEWORK_LINUX_DLL)  

BINARIES = \
	$(PROJETOP)  


RESGEN=resgen2

GAMEPADBRIDGE_DLL = $(BUILD_DIR)/GamepadBridge.dll
TAO_SDL_DLL = $(BUILD_DIR)/Tao.Sdl.dll
GAMEPADCONFIGCONTROLS_DLL = $(BUILD_DIR)/GamepadConfigControls.dll
LIDGREN_NETWORK_DLL = $(BUILD_DIR)/Lidgren.Network.dll
OPENTK_DLL = $(BUILD_DIR)/OpenTK.dll
MONOGAME_FRAMEWORK_LINUX_DLL = $(BUILD_DIR)/MonoGame.Framework.Linux.dll
PROJETOP = $(BUILD_DIR)/projetop

FILES = \
	AssemblyInfo.cs \
	Program.cs \
	ProjetOP.cs \
	Sprite.cs 

DATA_FILES = 

RESOURCES = 

EXTRAS = \
	projetop.in 

REFERENCES =  \
	System

DLL_REFERENCES =  \
	Externals/GamepadBridge.dll \
	Externals/GamepadConfigControls.dll \
	Externals/Lidgren.Network.dll \
	Externals/OpenTK.dll \
	Externals/Tao.Sdl.dll \
	Externals/MonoGame.Framework.Linux.dll

CLEANFILES = $(PROGRAMFILES) $(BINARIES) 

#Targets
all-local: $(ASSEMBLY) $(PROGRAMFILES) $(BINARIES)  $(top_srcdir)/config.make



$(eval $(call emit-deploy-target,GAMEPADBRIDGE_DLL))
$(eval $(call emit-deploy-target,TAO_SDL_DLL))
$(eval $(call emit-deploy-target,GAMEPADCONFIGCONTROLS_DLL))
$(eval $(call emit-deploy-target,LIDGREN_NETWORK_DLL))
$(eval $(call emit-deploy-target,OPENTK_DLL))
$(eval $(call emit-deploy-target,MONOGAME_FRAMEWORK_LINUX_DLL))
$(eval $(call emit-deploy-wrapper,PROJETOP,projetop,x))


$(eval $(call emit_resgen_targets))
$(build_xamlg_list): %.xaml.g.cs: %.xaml
	xamlg '$<'


$(ASSEMBLY_MDB): $(ASSEMBLY)
$(ASSEMBLY): $(build_sources) $(build_resources) $(build_datafiles) $(DLL_REFERENCES) $(PROJECT_REFERENCES) $(build_xamlg_list) $(build_satellite_assembly_list)
	make pre-all-local-hook prefix=$(prefix)
	mkdir -p $(shell dirname $(ASSEMBLY))
	make $(CONFIG)_BeforeBuild
	$(ASSEMBLY_COMPILER_COMMAND) $(ASSEMBLY_COMPILER_FLAGS) -out:$(ASSEMBLY) -target:$(COMPILE_TARGET) $(build_sources_embed) $(build_resources_embed) $(build_references_ref)
	make $(CONFIG)_AfterBuild
	make post-all-local-hook prefix=$(prefix)

install-local: $(ASSEMBLY) $(ASSEMBLY_MDB)
	make pre-install-local-hook prefix=$(prefix)
	make install-satellite-assemblies prefix=$(prefix)
	mkdir -p '$(DESTDIR)$(libdir)/$(PACKAGE)'
	$(call cp,$(ASSEMBLY),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(ASSEMBLY_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(SPACEGAME_EXE_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(GAMEPADBRIDGE_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(TAO_SDL_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(GAMEPADCONFIGCONTROLS_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(LIDGREN_NETWORK_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(OPENTK_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(MONOGAME_FRAMEWORK_LINUX_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	mkdir -p '$(DESTDIR)$(bindir)'
	$(call cp,$(PROJETOP),$(DESTDIR)$(bindir))
	make post-install-local-hook prefix=$(prefix)

uninstall-local: $(ASSEMBLY) $(ASSEMBLY_MDB)
	make pre-uninstall-local-hook prefix=$(prefix)
	make uninstall-satellite-assemblies prefix=$(prefix)
	$(call rm,$(ASSEMBLY),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(ASSEMBLY_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(SPACEGAME_EXE_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(GAMEPADBRIDGE_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(TAO_SDL_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(GAMEPADCONFIGCONTROLS_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(LIDGREN_NETWORK_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(OPENTK_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(MONOGAME_FRAMEWORK_LINUX_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(PROJETOP),$(DESTDIR)$(bindir))
	make post-uninstall-local-hook prefix=$(prefix)
