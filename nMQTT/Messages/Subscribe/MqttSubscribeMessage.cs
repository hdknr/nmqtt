﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Nmqtt
{
    public sealed class MqttSubscribeMessage : MqttMessage
    {
        /// <summary>
        /// Gets or sets the variable header contents. Contains extended metadata about the message
        /// </summary>
        /// <value>The variable header.</value>
        public MqttSubscribeVariableHeader VariableHeader { get; set; }

        /// <summary>
        /// Gets or sets the payload of the Mqtt Message.
        /// </summary>
        /// <value>The payload of the Mqtt Message.</value>
        public MqttSubscribePayload Payload { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MqttSubscribeMessage"/> class.
        /// </summary>
        /// <remarks>
        /// Only called via the MqttMessage.Create operation during processing of an Mqtt message stream.
        /// </remarks>
        public MqttSubscribeMessage()
        {
            this.Header = new MqttHeader().AsType(MqttMessageType.Subscribe);

            this.VariableHeader = new MqttSubscribeVariableHeader()
            {
            };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MqttSubscribeMessage"/> class.
        /// </summary>
        /// <param name="messageStream">The message stream positioned after the header.</param>
        internal MqttSubscribeMessage(MqttHeader header, Stream messageStream)
        {
            this.Header = header;
            ReadFrom(messageStream);
        }

        public override void ReadFrom(Stream messageStream)
        {
            this.VariableHeader = new MqttSubscribeVariableHeader(messageStream);
            this.Payload = new MqttSubscribePayload(Header, VariableHeader, messageStream);
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.ToString());
            sb.AppendLine(VariableHeader.ToString());
            sb.AppendLine(Payload.ToString());

            return sb.ToString();
        }

    }
}