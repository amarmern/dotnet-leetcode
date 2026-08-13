PARTITION → Parallelism + Ordering

OFFSET → Position + Progress + Replay

CONSUMER → Reads messages

CONSUMER GROUP → Consumers working together

PARTITIONS → Determine maximum parallelism per group

One of the major challenges I faced with Kafka was duplicate event processing and maintaining consistency between Kafka and our database.

The reason is that Kafka provides at-least-once processing in our setup. If the consumer successfully processes the business logic but fails before committing the offset, Kafka can deliver the same message again.

To handle this, I implemented idempotent processing. We generated/used a unique event or correlation ID and maintained the processing status in the database. Before applying the business operation, the consumer checked whether that event had already been processed. If it had, we skipped the duplicate.

Then interviewer may ask: "What other Kafka challenges?"

You should be ready with these 5 scenarios:

Challenge- What you should explain
Duplicate messages- At-least-once delivery → idempotent consumer
Consumer lag- Monitor lag → scale consumers → optimize processing
Consumer rebalance- Long processing / unstable consumers → tune polling and processing
Poison messages- Retry → limited retries → DLQ
Ordering- Same business entity → same partition key
