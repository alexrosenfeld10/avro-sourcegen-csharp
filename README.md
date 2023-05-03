# Avro Source Generation CSharp tests

This is a test project to demonstrate issues with generating Avro CSharp classes from Avro schema files that have
cross-file references to shared types.

## Setup

Running `dotnet build` will work out of the box. To replicate the issue, please see the xml comment above
the `_avroSchemasToGenerate` field in the [`AvroGenerator`](AvroSourceGenerator/AvroGenerator.cs) class.

To test this against `alfhv`'s fork (https://github.com/alfhv/avro), you will need to modify the dependencies in
the [AvroSourceGenerator.csproj](AvroSourceGenerator/AvroSourceGenerator.csproj) file

## Related links

* https://github.com/confluentinc/confluent-kafka-dotnet/issues/1127
* https://issues.apache.org/jira/browse/AVRO-3739
