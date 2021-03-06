﻿using System.Collections.Generic;
using TokenFilterFactory = Lucene.Net.Analysis.Util.TokenFilterFactory;

namespace org.apache.lucene.analysis.payloads
{

	/*
	 * Licensed to the Apache Software Foundation (ASF) under one or more
	 * contributor license agreements.  See the NOTICE file distributed with
	 * this work for additional information regarding copyright ownership.
	 * The ASF licenses this file to You under the Apache License, Version 2.0
	 * (the "License"); you may not use this file except in compliance with
	 * the License.  You may obtain a copy of the License at
	 *
	 *     http://www.apache.org/licenses/LICENSE-2.0
	 *
	 * Unless required by applicable law or agreed to in writing, software
	 * distributed under the License is distributed on an "AS IS" BASIS,
	 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
	 * See the License for the specific language governing permissions and
	 * limitations under the License.
	 */

	using TokenFilterFactory = TokenFilterFactory;

	/// <summary>
	/// Factory for <seealso cref="NumericPayloadTokenFilter"/>.
	/// <pre class="prettyprint">
	/// &lt;fieldType name="text_numpayload" class="solr.TextField" positionIncrementGap="100"&gt;
	///   &lt;analyzer&gt;
	///     &lt;tokenizer class="solr.WhitespaceTokenizerFactory"/&gt;
	///     &lt;filter class="solr.NumericPayloadTokenFilterFactory" payload="24" typeMatch="word"/&gt;
	///   &lt;/analyzer&gt;
	/// &lt;/fieldType&gt;</pre>
	/// </summary>
	public class NumericPayloadTokenFilterFactory : TokenFilterFactory
	{
	  private readonly float payload;
	  private readonly string typeMatch;

	  /// <summary>
	  /// Creates a new NumericPayloadTokenFilterFactory </summary>
	  public NumericPayloadTokenFilterFactory(IDictionary<string, string> args) : base(args)
	  {
		payload = requireFloat(args, "payload");
		typeMatch = require(args, "typeMatch");
		if (args.Count > 0)
		{
		  throw new System.ArgumentException("Unknown parameters: " + args);
		}
	  }

	  public override NumericPayloadTokenFilter create(TokenStream input)
	  {
		return new NumericPayloadTokenFilter(input,payload,typeMatch);
	  }
	}


}