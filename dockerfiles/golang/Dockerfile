FROM mcr.microsoft.com/vscode/devcontainers/base:0-focal

ENV GO_VERSION="1.17"
ENV PATH="${PATH}:/usr/local/go/bin:/home/vscode/go/bin"

RUN apt-get update && export DEBIAN_FRONTEND=noninteractive \
    && apt-get -y install --no-install-recommends software-properties-common \
    dnsutils unzip build-essential telnet \
    && apt-get -y install bash-completion \
    && apt-get -y clean && apt-get -y autoclean && apt-get -y autoremove
RUN curl -Lo /tmp/go.tar.gz https://golang.org/dl/go$GO_VERSION.linux-amd64.tar.gz && \
    rm -rf /usr/local/go && tar -C /usr/local -xzf /tmp/go.tar.gz && \
    rm /tmp/go.tar.gz

RUN apt-get update \
    && apt-get -y install python3-dev python3-pip python3-setuptools \
    && pip3 install thefuck \
    && apt-get -y clean && apt-get -y autoclean && apt-get -y autoremove

USER vscode
RUN go install github.com/cweill/gotests/...@latest
RUN go install github.com/ramya-rao-a/go-outline@latest
RUN go install github.com/uudashr/gopkgs/v2/cmd/gopkgs@latest
RUN go install github.com/fatih/gomodifytags@latest
RUN go install github.com/josharian/impl@latest
RUN go install github.com/haya14busa/goplay/cmd/goplay@latest
RUN go install github.com/go-delve/delve/cmd/dlv@latest
RUN go install github.com/go-delve/delve/cmd/dlv@master
RUN go install honnef.co/go/tools/cmd/staticcheck@latest
RUN go install golang.org/x/tools/gopls@latest
RUN curl -sSfL https://raw.githubusercontent.com/golangci/golangci-lint/master/install.sh | sh -s -- -b $(go env GOPATH)/bin v1.40.1
RUN echo "eval \$(thefuck --alias)" >> /home/vscode/.bashrc