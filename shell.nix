with import <nixpkgs> {};
  mkShell rec {
    name = "dotnet-env";
    dotnetPkg = with dotnetCorePackages;
      combinePackages [
        sdk_8_0-bin
        sdk_9_0-bin
        sdk_10_0-bin
      ];
    deps = [dotnetPkg];
    buildInputs = [
      nuget-to-json
    ];
    nativeBuildInputs = with pkgs;
      [
        # aot
        nix-ld
      ]
      ++ deps;

    NIX_LD_LIBRARY_PATH = with pkgs;
      lib.makeLibraryPath ([
          # aot
          stdenv.cc.cc
        ]
        ++ deps);
    LD_LIBRARY_PATH = with pkgs;
      lib.makeLibraryPath ([
          # aot
          stdenv.cc.cc
          # libskiasharp
          udev
          alsa-lib
          fontconfig
          glew
          fontconfig
          xorg.libX11
          xorg.libICE
          xorg.libSM
          icu
          openssl
        ]
        ++ deps
        ++ (with pkgs.xorg; [
          # Avalonia UI
          libX11
          libICE
          libSM
          libXi
          libXcursor
          libXext
          libXrandr
        ]));
    # NIX_LD = "${pkgs.stdenv.cc.libc_bin}/bin/ld.so";
    shellHook = ''
	  dotnet restore
      code ./Reader.code-workspace
    '';
  }
