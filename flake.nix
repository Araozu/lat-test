{
  description = "PeruControl Development Environment";

  inputs = {
    nixpkgs.url = "github:nixos/nixpkgs/nixos-unstable";
    flake-utils.url = "github:numtide/flake-utils";
  };

  outputs = { self, nixpkgs, flake-utils }:
    flake-utils.lib.eachDefaultSystem (system:
      let
        pkgs = import nixpkgs { inherit system; };
      in
      {
        devShells.default = pkgs.mkShellNoCC {
          name = "latesa";

          packages = with pkgs; [
            neovim
            tmux

            dotnet-sdk_10
            powershell
            ansible
          ];
        };
      }
    );
}
