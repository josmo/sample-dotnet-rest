FROM microsoft/dotnet
RUN mkdir -p /usr/src/app
WORKDIR /usr/src/app
COPY . /usr/src/app
CMD [ "./out/sample-dotnet-rest" ] 